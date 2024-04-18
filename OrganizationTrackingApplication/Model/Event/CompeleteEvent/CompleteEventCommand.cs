using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Event.CompeleteEvent
{
    /// <summary>
    /// Complete event - Get all tickets availibility to false
    /// </summary>
    public class CompleteEventCommand : IRequest<CompleteEventOutputModel>
    {
        public Guid EventId { get; set; }
    }
}