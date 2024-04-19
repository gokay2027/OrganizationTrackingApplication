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
            var resultModel = new CompleteEventOutputModel();

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

                    resultModel.IsSuccess = true;
                    resultModel.Message = "Event Completed successfully";
                }
                else
                {
                    resultModel.IsSuccess = true;
                    resultModel.Message = "Event could not be found";
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                resultModel.Message = ex.Message;
                resultModel.IsSuccess = false;
                return resultModel;
            }
        }
    }
}