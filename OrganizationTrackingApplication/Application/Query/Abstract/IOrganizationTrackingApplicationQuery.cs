using OrganizationTrackingApplicationApi.Model.Event.GetEvents;
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
        Task<EventListModel> GetAllEvents();

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
    }
}