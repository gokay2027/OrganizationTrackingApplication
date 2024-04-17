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

        public BuyTicketCommandHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<BuyTicketOutputModel> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var eventSet = await _eventRepository.GetSet();
                var eventsWithTicket = eventSet
                    .Include(a => a.Tickets)
                    .Where(a => a.Id.Equals(request.EventId))
                    .First();

                var availableTicket = eventsWithTicket.Tickets.Where(a => a.IsAvailable.Equals(true)).FirstOrDefault();

                //Ticketin owner idsini nulldan user idye çek
                //availableitisini false yap
                if (availableTicket != null)
                {
                    availableTicket.Update(availableTicket.Price, request.UserId, request.EventId);
                    availableTicket.UseTicket();
                    await _eventRepository.SaveChangesAsync();

                    return new BuyTicketOutputModel()
                    {
                        IsSuccess = true,
                        Message = "Ticket has been bought successfully"
                    };
                }

                return new BuyTicketOutputModel()
                {
                    IsSuccess = true,
                    Message = "Ticket could not be bought"
                };
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