using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Event.AddEvent;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.EventCommand.AddEvent
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, AddEventOutputModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;

        public AddEventCommandHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<AddEventOutputModel> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var eventToBeAdded = new Event(
                request.Name,
                request.EventTime,
                request.LocationId,
                request.EventTypeId,
                request.OrganizatorId);

                eventToBeAdded.AddCreatedTicketForEvent(request.TicketNumber, request.TicketPrice);

                eventToBeAdded.AddRulesForEvent(request.Rules);

                await _eventRepository.Insert(eventToBeAdded);

                return new AddEventOutputModel
                {
                    IsSuccess = true,
                    Message = "Event Has been added successfully"
                };
            }
            catch (Exception ex)
            {
                return new AddEventOutputModel()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}