using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganizationTrackingApplicationApi.Model.Event.AddEvent;
using OrganizationTrackingApplicationApi.Model.Follow.FollowPerson;
using OrganizationTrackingApplicationApi.Model.Location.AddLocation;
using OrganizationTrackingApplicationApi.Model.Location.UpdateLocation;
using OrganizationTrackingApplicationApi.Model.Organizator.AddOrganizator;
using OrganizationTrackingApplicationApi.Model.Rule.AddRuleToEvent;
using OrganizationTrackingApplicationApi.Model.User.AddUser;
using OrganizationTrackingApplicationApi.Model.User.ChangePassword;
using OrganizationTrackingApplicationApi.Model.User.DeleteUser;
using OrganizationTrackingApplicationApi.Model.User.UpdateUser;

namespace OrganizationTrackingApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrganizationTrackingApplicationCommandController
    {
        private readonly IMediator _mediator;

        public OrganizationTrackingApplicationCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Commands

        [HttpPost]
        public async Task<AddUserOutputModel> RegisterUser([FromBody] AddUserCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut]
        public async Task<DeleteUserOutputModel> DeleteUser([FromBody] DeleteUserCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut]
        public async Task<UpdateUserOutputModel> UpdateUser([FromBody] UpdateUserCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut]
        public async Task<ChangePasswordOutputModel> ChangePassword([FromBody] ChangePasswordCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<AddLocationOutputModel> AddLocation([FromBody] AddLocationCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<AddEventOutputModel> AddEvent([FromBody] AddEventCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<AddOrganizatorOutputModel> AddOrganizator([FromBody] AddOrganizatorCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut]
        public async Task<UpdateLocationOutputModel> UpdateLocation([FromBody] UpdateLocationCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<AddRuleToEventOutputModel> AddRuleToEvent([FromBody] AddRuleToEventCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<FollowPersonOutputModel> FollowPerson([FromBody] FollowPersonCommand model)
        {
            return await _mediator.Send(model);
        }

        #endregion Commands
    }
}