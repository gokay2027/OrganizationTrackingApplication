using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Rule.AddRuleToEvent
{
    public class AddRuleToEventCommand : IRequest<AddRuleToEventOutputModel>
    {
        public Guid EventId { get; set; }
        public string RuleDescription { get; set; }
    }
}