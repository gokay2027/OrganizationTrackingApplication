using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Event.AddEventWithModelCommand
{
    public class AddEventWithModelCommand : IRequest<AddEventWithModelOutputModel>
    {
        public string EventName { get; set; }

        public string AddressDescription { get; set; }

        public string FormattedAddressName { get; set; }    

        public string EventDescription { get; set; }

        public string EventTime { get; set; }

        public Guid EventTypeId { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public Guid CreatedById { get; set; }

        public int TicketPrice { get; set; }

        public int TicketNumber { get; set; }
    }
}