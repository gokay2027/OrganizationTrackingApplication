using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationApi.Model.Event.GetEvents;
using OrganizationTrackingApplicationApi.Model.User.GetUser;
using OrganizationTrackingApplicationApi.Model.User.GetUsers;
using OrganizationTrackingApplicationApi.Model.User.LoginUser;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Query
{
    public class OrganizationTrackingApplicationQuery : IOrganizationTrackingApplicationQuery
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IGenericRepository<Rating> _ratingRepository;

        public OrganizationTrackingApplicationQuery(IGenericRepository<User> userRepository, IGenericRepository<Event> eventRepository, IGenericRepository<Rating> ratingRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _ratingRepository = ratingRepository;
        }

        public async Task<EventListModel> GetAllEvents()
        {
            try
            {
                var eventSet = await _eventRepository.GetSet();
                var allIncludedEventList = eventSet
                    .Include(a => a.Organizator)
                    .Include(a => a.EventType)
                    .Include(a => a.Location)
                    .Include(a => a.Rules)
                    .OrderBy(a => a.CreatedDate)
                    .ToList();

                var eventListModel = new EventListModel();

                foreach (var item in allIncludedEventList)
                {
                    List<string> rules = new List<string>();

                    item.Rules.ForEach(a =>
                    {
                        rules.Add(a.Rule);
                    });

                    eventListModel.EventList.Add(new EventListItem
                    {
                        EventTime = item.EventTime,
                        EventTypeName = item.EventType.Name,
                        IsCompleted = item.IsCompleted,
                        Name = item.Name,
                        OrganizatorName = item.Organizator.Name,
                        LocationAdress = item.Location.FormattedName,
                        Rules = rules
                    });
                }
                eventListModel.Message = "Events were get successfully";
                eventListModel.IsSuccess = true;
                eventListModel.ItemCount = allIncludedEventList.Count;

                return eventListModel;
            }
            catch (Exception ex)
            {
                return new EventListModel
                {
                    ItemCount = 0,
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<EventListModel> GetEventsByFilter(EventSearchModel eventFilter)
        {
            var filter = EventFilterBuilder(eventFilter);
            var eventListModel = new EventListModel();
            try
            {
                var eventSet = await _eventRepository.GetSet();
                var allIncludedEventList = eventSet
                    .Include(a => a.Organizator)
                    .Include(a => a.EventType)
                    .Include(a => a.Location)
                    .Include(a=>a.Rules)
                    .OrderBy(a => a.CreatedDate).Where(filter)
                    .ToList();

                foreach (var item in allIncludedEventList)
                {
                    List<string> rules = new List<string>();

                    item.Rules.ForEach(a =>
                    {
                        rules.Add(a.Rule);
                    });

                    eventListModel.EventList.Add(new EventListItem
                    {
                        EventTime = item.EventTime,
                        EventTypeName = item.EventType.Name,
                        IsCompleted = item.IsCompleted,
                        Name = item.Name,
                        OrganizatorName = item.Organizator.Name,
                        LocationAdress = item.Location.FormattedName,
                        Rules = rules
                    });
                }
                eventListModel.Message = "Events queried successfully";
                eventListModel.IsSuccess = true;
                eventListModel.ItemCount = 0;
                return eventListModel;
            }
            catch (Exception ex)
            {
                eventListModel.Message = ex.Message;
                eventListModel.IsSuccess = false;
                eventListModel.ItemCount = 0;
                return eventListModel;
            }
        }

        public async Task<UserInformationModel> GetUserInformation(UserInformationInputModel inputModel)
        {
            try
            {
                var userSet = await _userRepository.GetSet();

                var user = userSet
                     .Include(a => a.Followers)
                     .Include(a => a.Followeds)
                     .Include(a => a.Tickets)
                     .Where(a => a.Id.Equals(inputModel.Id))
                     .First();

                var userInformation = new UserInformationModel()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    FollowCount = user.Followeds.Count(),
                    FollowerCount = user.Followers.Count(),
                };

                foreach (var ticket in user.Tickets)
                {
                    userInformation.EventsJoined.Add(ticket.Event.Name);
                }

                userInformation.Message = "User queried successfully";
                userInformation.IsSuccess = true;

                return userInformation;
            }
            catch (Exception ex)
            {
                return new UserInformationModel()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<UserListModel> GetUserListByFilter(UserListSearchModel searchModel)
        {
            try
            {
                var filter = UserFilterBuilder(searchModel);

                var userSet = await _userRepository.GetByFilter(filter);
                var userList = userSet.ToList();

                var resultModel = new UserListModel();

                foreach (var user in userList)
                {
                    resultModel.ResultList.Add(new UserItemModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                    });
                }
                resultModel.ItemCount = userList.Count;
                resultModel.IsSuccess = true;
                resultModel.Message = "Users queried successfully";
                return resultModel;
            }
            catch (Exception ex)
            {
                return new UserListModel
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    ItemCount = 0,
                };
            }
        }

        public async Task<UserInformationModel> LoginUser(LoginUserModel loginModel)
        {
            var userSet = await _userRepository.GetSet();

            var user = userSet
                 .Include(a => a.Followers)
                 .Include(a => a.Followeds)
                 .Include(a => a.Tickets)
                 .Where(a => a.Email.Equals(loginModel.Email) && a.Password.Equals(loginModel.Password))
                 .First();

            var userInformation = new UserInformationModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                FollowCount = user.Followeds.Count(),
                FollowerCount = user.Followers.Count(),
            };

            foreach (var ticket in user.Tickets)
            {
                userInformation.EventsJoined.Add(ticket.Event.Name);
            }

            userInformation.Message = "User queried successfully";
            userInformation.IsSuccess = true;

            return userInformation;
        }

        private static System.Linq.Expressions.Expression<Func<User, bool>> UserFilterBuilder(UserListSearchModel userSearchModel)
        {
            var predicateBuilder = LinqKit.PredicateBuilder.New<User>();

            if (!userSearchModel.Name.IsNullOrEmpty())
                predicateBuilder.And(a => a.Name.Contains(userSearchModel.Name));

            if (!userSearchModel.Email.IsNullOrEmpty())
                predicateBuilder.And(a => a.Email.Contains(userSearchModel.Email));

            return predicateBuilder;
        }

        private static System.Linq.Expressions.Expression<Func<Event, bool>> EventFilterBuilder(EventSearchModel eventFilter)
        {
            var predicateBuilder = LinqKit.PredicateBuilder.New<Event>();

            if (!eventFilter.LocationAdress.IsNullOrEmpty())
                predicateBuilder.And(a => a.Location.FormattedName.Contains(eventFilter.LocationAdress));

            if (!eventFilter.OrganizatorName.IsNullOrEmpty())
                predicateBuilder.And(a => a.Organizator.Name.Contains(eventFilter.OrganizatorName));

            if (!eventFilter.EventName.IsNullOrEmpty())
                predicateBuilder.And(a => a.Name.Contains(eventFilter.EventName));

            if (!eventFilter.EventTypeName.IsNullOrEmpty())
                predicateBuilder.And(a => a.EventType.Name.Contains(eventFilter.EventTypeName));

            return predicateBuilder;
        }
    }
}