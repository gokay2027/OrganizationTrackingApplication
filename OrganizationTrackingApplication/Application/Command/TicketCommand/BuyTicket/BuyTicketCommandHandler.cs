using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Ticket.BuyTicket;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using System.Data.Entity;

namespace OrganizationTrackingApplicationApi.Application.Command.TicketCommand.BuyTicket
{
    public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand, BuyTicketOutputModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IGenericRepository<User> _userRepository;

        public BuyTicketCommandHandler(IGenericRepository<Event> eventRepository, IGenericRepository<User> userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        public async Task<BuyTicketOutputModel> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userSet = await _userRepository.GetSet();
                var userWithBalance = userSet
                    .Include(a => a.Balance)
                    .First(a => a.Id.Equals(request.UserId));

                var eventSet = await _eventRepository.GetSet();
                var eventsWithTicket = eventSet
                    .Include(a => a.Tickets)
                    .Where(a => a.Id.Equals(request.EventId))
                    .First();

                var availableTicket = eventsWithTicket.Tickets.Find(a => a.IsAvailable.Equals(true));

                if (availableTicket != null)
                {
                    if (availableTicket.Price < userWithBalance.Balance.Credit)
                    {
                        availableTicket.BuyTicket(request.UserId);
                        userWithBalance.Balance.SpendCredit(availableTicket.Price);

                        await _eventRepository.SaveChangesAsync();
                        return new BuyTicketOutputModel()
                        {
                            IsSuccess = true,
                            Message = "Ticket has been bought successfully"
                        };
                    }
                    else
                    {
                        return new BuyTicketOutputModel()
                        {
                            IsSuccess = false,
                            Message = "Not enough balance"
                        };
                    }
                }
                else
                {
                    return new BuyTicketOutputModel()
                    {
                        IsSuccess = true,
                        Message = "There is no ticket available"
                    };
                }
            }
            catch (Exception ex)
            {
                return new BuyTicketOutputModel()
                {
                    IsSuccess = true,
                    Message = ex.Message
                };
            }
        }
    }
}