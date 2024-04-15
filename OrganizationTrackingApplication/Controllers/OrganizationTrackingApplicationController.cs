using Entities.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationApi.Model.Event.GetEvents;
using OrganizationTrackingApplicationApi.Model.User.AddUser;
using OrganizationTrackingApplicationApi.Model.User.ChangePassword;
using OrganizationTrackingApplicationApi.Model.User.DeleteUser;
using OrganizationTrackingApplicationApi.Model.User.GetUser;
using OrganizationTrackingApplicationApi.Model.User.GetUsers;
using OrganizationTrackingApplicationApi.Model.User.LoginUser;
using OrganizationTrackingApplicationApi.Model.User.UpdateUser;

namespace OrganizationTrackingApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrganizationTrackingApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrganizationTrackingApplicationQuery _query;

        public OrganizationTrackingApplicationController(IMediator mediator, IOrganizationTrackingApplicationQuery query)
        {
            _mediator = mediator;
            _query = query;
        }

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
        public async Task<ChangePasswordOutputModel> ChanePassword([FromBody] ChangePasswordCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpGet]
        public Task<EventListModel> GetAllEvents()
        {
            return _query.GetAllEvents();
        }

        [HttpGet]
        public Task<EventListModel> GetEventsByFilter([FromQuery] EventSearchModel eventFilter)
        {
            return _query.GetEventsByFilter(eventFilter);
        }

        [HttpGet]
        public Task<UserInformationModel> GetUserInformation([FromQuery] UserInformationInputModel inputModel)
        {
            return _query.GetUserInformation(inputModel);
        }

        [HttpGet]
        public Task<UserListModel> GetUserListByFilter([FromQuery] UserListSearchModel searchModel)
        {
            return _query.GetUserListByFilter(searchModel);
        }

        [HttpPut]
        public Task<UserInformationModel> LoginUser([FromBody]LoginUserModel loginModel)
        {
            return _query.LoginUser(loginModel);
        }
    }
}