using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Rule.AddRuleToEvent;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using System.Data.Entity;

namespace OrganizationTrackingApplicationApi.Application.Command.RuleCommand.AddRuleToEvent
{
    public class AddRuleToEventCommandHandler : IRequestHandler<AddRuleToEventCommand, AddRuleToEventOutputModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;

        public AddRuleToEventCommandHandler(IGenericRepository<Event> eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        public async Task<AddRuleToEventOutputModel> Handle(AddRuleToEventCommand request, CancellationToken cancellationToken)
        {
            var output = new AddRuleToEventOutputModel();

            try
            {
                var eventSet = await _eventRepository.GetSet();
                var eventWithRules = eventSet.Include(a => a.Rules);

                var @event = eventWithRules.First(a => a.Id.Equals(request.EventId));

                @event.AddRuleToEvent(request.RuleDescription);

                await _eventRepository.SaveChangesAsync();

                output.Message = "Rule Added to Event successfully";
                output.IsSuccess = true;
                return output;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.IsSuccess = true;
                return output;
            }
        }
    }
}