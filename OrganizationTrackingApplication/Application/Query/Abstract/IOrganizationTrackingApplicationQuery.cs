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

namespace OrganizationTrackingApplicationApi.Application.Query.Abstract
{
    public interface IOrganizationTrackingApplicationQuery
    {
        /// <summary>
        /// Gets All events
        /// </summary>
        /// <returns></returns>
        Task<EventListModel> GetAllEvents(Guid? userId);

        /// <summary>
        /// Gets events by Filter
        /// </summary>
        /// <param name="eventFilter"></param>
        /// <returns></returns>
        Task<EventListModel> GetEventsByFilter(EventSearchModel eventFilter);

        /// <summary>
        /// Gets user information by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<UserInformationModel> GetUserInformation(UserInformationInputModel inputModel);

        /// <summary>
        /// Gets user Search result
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<UserListModel> GetUserListByFilter(UserListSearchModel searchModel);

        /// <summary>
        /// Login for user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        Task<UserInformationModel> LoginUser(LoginUserModel loginModel);

        /// <summary>
        /// Gets organiztor list by filter
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<OrganizatorListModel> GetOrganizatorsByFilter(OrganizatorSearchModel searchModel);

        /// <summary>
        /// Gets All Organizators
        /// </summary>
        /// <returns></returns>
        Task<OrganizatorListModel> GetAllOrganizators();

        /// <summary>
        /// Gets Organizator by Id
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<OrganizatorInformationModel> GetOrganizatorById(OrganizatorInformationInputModel searchModel);

        /// <summary>
        /// Gets events by Location from the google map api data
        /// </summary>
        /// <returns></returns>
        Task<EventListModel> GetEventsByLocation(LocationSearchModelForEvent locationSearchModel);

        /// <summary>
        /// Gets All Locations
        /// </summary>
        /// <returns></returns>
        Task<GetAllLocationsListModel> GetAllLocations();

        /// <summary>
        /// Gets all event types
        /// </summary>
        /// <returns></returns>
        Task<GetAllEventTypesListModel> GetAllEventTypes();

        /// <summary>
        /// Gets user's follows by user Id
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<GetFollowsListModel> GetFollowsList(UserFollowsSearchModel searchModel);

        /// <summary>
        /// Provides data for event suggestion
        /// </summary>
        /// <returns></returns>
        Task SuggestEventDataForML();

        /// <summary>
        /// Provides data for ticket price suggestion
        /// </summary>
        /// <returns></returns>
        Task SuggestTicketPriceDataForML();
    }
}