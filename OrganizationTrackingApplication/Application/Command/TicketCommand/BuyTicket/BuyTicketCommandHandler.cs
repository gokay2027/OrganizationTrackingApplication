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
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<Balance> _balanceRepository;

        public BuyTicketCommandHandler(IGenericRepository<Event> eventRepository, IGenericRepository<User> userRepository, IGenericRepository<Ticket> ticketRepository, IGenericRepository<Balance> balanceRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;                                                                                                                                                                                                                                       
            _balanceRepository = balanceRepository;
        }

        public async Task<BuyTicketOutputModel> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userSet = await _balanceRepository.GetSet();
                var balanceWithUser = userSet.Include(a => a.User).FirstOrDefault(a=>a.UserId.Equals(request.UserId));

                var ticketSet = await _ticketRepository.GetByFilter(a => a.EventId.Equals(request.EventId));
                var availableTicket = ticketSet.ToList().FirstOrDefault(a => a.IsAvailable.Equals(true));

                if (availableTicket != null)
                {
                    if (availableTicket.Price < balanceWithUser.Credit)
                    {
                        availableTicket.BuyTicket(request.UserId);
                        balanceWithUser.SpendCredit(availableTicket.Price);

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
                        IsSuccess = false,
                        Message = "There is no ticket available"
                    };
                }
            }
            catch (Exception ex)
            {
                return new BuyTicketOutputModel()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}