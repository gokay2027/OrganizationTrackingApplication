using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Event.AddEventWithModelCommand
{
    public class AddEventWithModelCommand : IRequest<AddEventWithModelOutputModel>
    {
        public string EventName { get; set; }

        public string AdressDescription { get; set; }

        public string FormattedAddressName { get; set; }    

        public string DetailDescription { get; set; }

        public string EventTime { get; set; }

        public Guid EventTypeId { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public Guid CreatedById { get; set; }
    }
}