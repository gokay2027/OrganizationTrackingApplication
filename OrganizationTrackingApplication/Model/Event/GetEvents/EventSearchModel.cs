﻿namespace OrganizationTrackingApplicationApi.Model.Event.GetEvents
{
    public class EventSearchModel
    {
        public Guid? EventId { get; set; }
        public string? EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public string? EventTypeName { get; set; }
        public string? OrganizatorName { get; set; }
        public string? LocationAdress { get; set; }
        public int? Radius { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public Guid? JoinedEventsByUserId { get; set; }
        public Guid? CreatedEventsByUserId { get; set; }
        public Guid? UserId { get; set; }
    }
}