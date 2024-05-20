using Microsoft.AspNetCore.Mvc;
using OrganizationTrackingApplicationApi.Application.DummyCommand;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationApi.Model.Event.GetEventByLocation;
using OrganizationTrackingApplicationApi.Model.Event.GetEvents;
using OrganizationTrackingApplicationApi.Model.EventType;
using OrganizationTrackingApplicationApi.Model.Follow.GetFollows;
using OrganizationTrackingApplicationApi.Model.Location.GetAllLocations;
using OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorByFilter;
using OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorById;
using OrganizationTrackingApplicationApi.Model.User.GetUser;
using OrganizationTrackingApplicationApi.Model.User.GetUsers;
using OrganizationTrackingApplicationApi.Model.User.LoginUser;

namespace OrganizationTrackingApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrganizationTrackingApplicationQueryController : ControllerBase
    {
        private readonly IOrganizationTrackingApplicationQuery _query;
        private readonly IDummyCommand _dummyCommand;

        public OrganizationTrackingApplicationQueryController(IOrganizationTrackingApplicationQuery query, IDummyCommand dummyCommand)
        {
            _query = query;
            _dummyCommand = dummyCommand;
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

        [HttpGet]
        public Task<GetFollowsListModel> GetFollowsList([FromQuery] UserFollowsSearchModel searchModel)
        {
            return _query.GetFollowsList(searchModel);
        }


        [HttpPost]
        public async Task DummyData()
        {
            await _dummyCommand.AddDummyData();
        }

        #endregion Queries
    }
}