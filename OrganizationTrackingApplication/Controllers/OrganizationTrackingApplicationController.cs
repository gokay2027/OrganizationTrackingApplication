using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        public OrganizationTrackingApplicationController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<ChangePasswordOutputModel> UpdateUser([FromBody] ChangePasswordCommand model)
        {
            return await _mediator.Send(model);
        }
    }
}