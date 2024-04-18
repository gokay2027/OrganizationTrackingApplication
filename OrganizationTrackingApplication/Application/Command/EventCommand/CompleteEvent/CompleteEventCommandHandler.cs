using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Event.CompeleteEvent;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.EventCommand.CompleteEvent
{
    public class CompleteEventCommandHandler : IRequestHandler<CompleteEventCommand, CompleteEventOutputModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;

        public Task<CompleteEventOutputModel> Handle(CompleteEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}