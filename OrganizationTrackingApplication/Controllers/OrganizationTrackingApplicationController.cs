using Entities.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationApi.Model.User.AddUser;
using OrganizationTrackingApplicationApi.Model.User.ChangePassword;
using OrganizationTrackingApplicationApi.Model.User.DeleteUser;
using OrganizationTrackingApplicationApi.Model.User.UpdateUser;

namespace OrganizationTrackingApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrganizationTrackingApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserQuery _userQuery;
        public OrganizationTrackingApplicationController(IMediator mediator, IUserQuery userQuery)
        {
            _mediator = mediator;
            _userQuery = userQuery;
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
        public async Task<List<User>> GetAllUsers()
        {
            return await _userQuery.GetAllUsers();
        }

    }
}