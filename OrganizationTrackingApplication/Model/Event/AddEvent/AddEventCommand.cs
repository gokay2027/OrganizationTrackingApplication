using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Event.AddEvent
{
    //Also creates 1000 ticket for users
    public class AddEventCommand : IRequest<AddEventOutputModel>
    {
        public string Name { get; set; }
        public DateTime EventTime { get; set; }
        public Guid EventTypeId { get; set; }
        public Guid OrganizatorId { get; set; }
        public Guid LocationId { get; set; }
        public string EventDescription { get; set; }
        public int TicketNumber { get; set; }
        public int TicketPrice { get; set; }
        public List<string> Rules { get; set; } = new();
    }
}