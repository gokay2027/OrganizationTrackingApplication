using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationApi.Model.Event.AddEvent;
using OrganizationTrackingApplicationApi.Model.Event.GetEventByLocation;
using OrganizationTrackingApplicationApi.Model.Event.GetEvents;
using OrganizationTrackingApplicationApi.Model.EventType;
using OrganizationTrackingApplicationApi.Model.Location.AddLocation;
using OrganizationTrackingApplicationApi.Model.Location.GetAllLocations;
using OrganizationTrackingApplicationApi.Model.Location.UpdateLocation;
using OrganizationTrackingApplicationApi.Model.Organizator.AddOrganizator;
using OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorByFilter;
using OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorById;
using OrganizationTrackingApplicationApi.Model.Rule.AddRuleToEvent;
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

        #region Queries

        [HttpGet]
        public Task<EventListModel> GetAllEvents()
        {
            return _query.GetAllEvents();
        }

        [HttpGet]
        public Task<EventListModel> GetEventsByFilter([FromQuery] EventSearchModel searchModel)
        {
            return _query.GetEventsByFilter(searchModel);
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
        public Task<UserInformationModel> LoginUser([FromBody] LoginUserModel loginModel)
        {
            return _query.LoginUser(loginModel);
        }

        [HttpGet]
        public async Task<GetAllLocationsListModel> GetAllLocations()
        {
            return await _query.GetAllLocations();
        }

        [HttpGet]
        public Task<OrganizatorListModel> GetOrganizatorsByFilter([FromQuery] OrganizatorSearchModel searchModel)
        {
            return _query.GetOrganizatorsByFilter(searchModel);
        }

        [HttpGet]
        public Task<OrganizatorListModel> GetAllOrganizators()
        {
            return _query.GetAllOrganizators();
        }

        [HttpGet]
        public Task<OrganizatorInformationModel> GetOrganizatorById([FromQuery] OrganizatorInformationInputModel searchModel)
        {
            return _query.GetOrganizatorById(searchModel);
        }

        [HttpGet]
        public Task<EventListModel> GetEventsByLocation([FromQuery] LocationSearchModelForEvent searchModel)
        {
            return _query.GetEventsByLocation(searchModel);
        }

        [HttpGet]
        public Task<GetAllEventTypesListModel> GetAllEventTypes()
        {
            return _query.GetAllEventTypes();
        }

        #endregion Queries

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
        public async Task<ChangePasswordOutputModel> ChanePassword([FromBody] ChangePasswordCommand model)
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

        [HttpPut]
        public async Task<AddRuleToEventOutputModel> UpdateLocation([FromBody] AddRuleToEventCommand model)
        {
            return await _mediator.Send(model);
        }

        #endregion Commands
    }
}