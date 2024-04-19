using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Event.CompeleteEvent;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using System.Data.Entity;

namespace OrganizationTrackingApplicationApi.Application.Command.EventCommand.CompleteEvent
{
    /// <summary>
    /// event is completed will be switched true and tickets' availability of the event will be false
    /// </summary>
    public class CompleteEventCommandHandler : IRequestHandler<CompleteEventCommand, CompleteEventOutputModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;

        public CompleteEventCommandHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<CompleteEventOutputModel> Handle(CompleteEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var eventSet = await _eventRepository.GetSet();
                var eventWithTickets = eventSet.Include(a => a.Tickets);

                var @event = eventWithTickets.First(a => a.Id.Equals(request.EventId));
                if (@event != null)
                {
                    foreach (var ticket in @event.Tickets)
                    {
                        ticket.SetTicketAvailability(false);
                    }
                    @event.CompleteEvent();
                    await _eventRepository.SaveChangesAsync();

                    return new CompleteEventOutputModel()
                    {
                        IsSuccess = true,
                        Message = "Event was completed successfully"
                    };
                }
                else
                {
                    return new CompleteEventOutputModel()
                    {
                        IsSuccess = false,
                        Message = "Event could not be found"
                    };
                }
            }
            catch (Exception ex)
            {
                return new CompleteEventOutputModel()
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}