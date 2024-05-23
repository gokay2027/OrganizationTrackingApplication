using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationApi.Model.Event.GetEventByLocation;
using OrganizationTrackingApplicationApi.Model.Event.GetEvents;
using OrganizationTrackingApplicationApi.Model.EventType;
using OrganizationTrackingApplicationApi.Model.Follow.GetFollows;
using OrganizationTrackingApplicationApi.Model.Location.GetAllLocations;
using OrganizationTrackingApplicationApi.Model.MLData.SuggestEvent;
using OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorByFilter;
using OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorById;
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
        private readonly IGenericRepository<Organizator> _organizatorRepository;
        private readonly IGenericRepository<Location> _locationRepository;
        private readonly IGenericRepository<EventType> _eventTypeRepository;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<Rating> _ratingRepository;

        public OrganizationTrackingApplicationQuery(IGenericRepository<User> userRepository,
            IGenericRepository<Event> eventRepository,
            IGenericRepository<Organizator> organizatorRepository,
            IGenericRepository<Location> locationRepository,
            IGenericRepository<EventType> eventTypeRepository,
            IGenericRepository<Ticket> ticketRepository,
            IGenericRepository<Rating> ratingRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _organizatorRepository = organizatorRepository;
            _locationRepository = locationRepository;
            _eventTypeRepository = eventTypeRepository;
            _ticketRepository = ticketRepository;
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
                    .Include(a => a.Rules)
                    .OrderBy(a => a.CreatedDate)
                    .Where(filter)
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
                 .FirstOrDefault();

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

        public async Task<OrganizatorListModel> GetOrganizatorsByFilter(OrganizatorSearchModel searchModel)
        {
            var filter = OrganizatorFilterBuilder(searchModel);
            OrganizatorListModel resultModel = new();
            try
            {
                var organizatorSet = await _organizatorRepository.GetSet();

                var organizatorList = organizatorSet
                    .Include(a => a.Events)
                    .ThenInclude(a => a.Ratings)
                    .Where(filter)
                    .ToList();

                foreach (var organizator in organizatorList)
                {
                    var organizatorListItem = new OrganizatorListItemModel
                    {
                        Id = organizator.Id,
                        Name = organizator.Name,
                    };

                    foreach (var organizatorEvent in organizator.Events)
                    {
                        var organizatorEventListItem = new OrganizatorEventListItem
                        {
                            Id = organizatorEvent.Id,
                            Name = organizator.Name,
                        };

                        if (organizatorEvent.Ratings.Count.Equals(0))
                        {
                            organizatorEventListItem.AverageRating = 0;
                        }
                        else
                        {
                            organizatorEventListItem.AverageRating = (decimal)organizatorEvent.Ratings.Average(a => a.Rate);
                        }
                    }

                    resultModel.ResultList.Add(organizatorListItem);
                }

                resultModel.IsSuccess = true;
                resultModel.ItemCount = organizatorList.Count;
                resultModel.Message = "Organizators were listed successfully";

                return resultModel;
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Message = ex.Message;
                resultModel.ItemCount = 0;
                return resultModel;
            }
        }

        public async Task<OrganizatorListModel> GetAllOrganizators()
        {
            OrganizatorListModel resultModel = new();
            try
            {
                var organizatorSet = await _organizatorRepository.GetSet();

                var organizatorList = organizatorSet
                    .Include(a => a.Events)
                    .ThenInclude(a => a.Ratings)
                    .ToList();

                foreach (var organizator in organizatorList)
                {
                    var organizatorListItem = new OrganizatorListItemModel
                    {
                        Id = organizator.Id,
                        Name = organizator.Name,
                    };

                    foreach (var organizatorEvent in organizator.Events)
                    {
                        var organizatorEventListItem = new OrganizatorEventListItem
                        {
                            Id = organizatorEvent.Id,
                            Name = organizator.Name,
                        };

                        if (organizatorEvent.Ratings.Count.Equals(0))
                        {
                            organizatorEventListItem.AverageRating = 0;
                        }
                        else
                        {
                            organizatorEventListItem.AverageRating = (decimal)organizatorEvent.Ratings.Average(a => a.Rate);
                        }
                    }

                    resultModel.ResultList.Add(organizatorListItem);
                }

                resultModel.IsSuccess = true;
                resultModel.ItemCount = organizatorList.Count;
                resultModel.Message = "Organizators were listed successfully";
                return resultModel;
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Message = ex.Message;
                resultModel.ItemCount = 0;
                return resultModel;
            }
        }

        public async Task<OrganizatorInformationModel> GetOrganizatorById(OrganizatorInformationInputModel searchModel)
        {
            OrganizatorInformationModel resultModel = new();
            try
            {
                var organizatorSet = await _organizatorRepository.GetSet();

                var organizator = organizatorSet
                    .Include(a => a.Events)
                    .ThenInclude(a => a.Ratings)
                    .Where(a => a.Id.Equals(searchModel.Id))
                    .First();

                var organizatorListItem = new OrganizatorInformationModel
                {
                    Id = organizator.Id,
                    Name = organizator.Name,
                };

                foreach (var organizatorEvent in organizator.Events)
                {
                    var organizatorEventListItem = new OrganizatorEventsListItem
                    {
                        Id = organizatorEvent.Id,
                        Name = organizator.Name,
                    };

                    if (organizatorEvent.Ratings.Count.Equals(0))
                    {
                        organizatorEventListItem.AverageRating = 0;
                    }
                    else
                    {
                        organizatorEventListItem.AverageRating = (decimal)organizatorEvent.Ratings.Average(a => a.Rate);
                    }
                }

                resultModel.IsSuccess = true;
                resultModel.Message = "Organizator queried successfully";

                return resultModel;
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Message = ex.Message;
                return resultModel;
            }
        }

        public async Task<EventListModel> GetEventsByLocation(LocationSearchModelForEvent locationSearchModel)
        {
            var eventListModel = new EventListModel();

            try
            {
                var eventSet = await _eventRepository.GetSet();

                var locationFilter = EventLocationByFilter(locationSearchModel);

                var eventsByLocation = eventSet
                    .Include(a => a.Organizator)
                     .Include(a => a.EventType)
                     .Include(a => a.Location)
                     .Include(a => a.Rules)
                     .OrderBy(a => a.CreatedDate)
                    .Where(locationFilter)
                    .ToList();

                foreach (var item in eventsByLocation)
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
                eventListModel.ItemCount = eventsByLocation.Count;
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

        public async Task<GetAllLocationsListModel> GetAllLocations()
        {
            GetAllLocationsListModel resultModel = new();

            try
            {
                var allLocations = await _locationRepository.GetAll();
                foreach (var location in allLocations)
                {
                    resultModel.ResultList.Add(new LocationListItem
                    {
                        Id = location.Id,
                        FormattedName = location.FormattedName,
                        Description = location.Description,
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                    });
                }
                resultModel.IsSuccess = true;
                resultModel.ItemCount = allLocations.Count();
                resultModel.Message = "Locations queried successfully";
                return resultModel;
            }
            catch (Exception ex)
            {
                resultModel.Message = ex.Message;
                resultModel.IsSuccess = false;
                resultModel.ItemCount = 0;
                return resultModel;
            }
        }

        public async Task<GetAllEventTypesListModel> GetAllEventTypes()
        {
            GetAllEventTypesListModel resultModel = new();
            try
            {
                var eventTypes = await _eventTypeRepository.GetAll();

                foreach (var eventType in eventTypes)
                {
                    resultModel.ResultList.Add(new EventTypeListItem
                    {
                        Id = eventType.Id,
                        Name = eventType.Name,
                    });
                }

                resultModel.IsSuccess = true;
                resultModel.Message = "Event types queried Successfully";
                resultModel.ItemCount = eventTypes.Count();
                return resultModel;
            }
            catch (Exception ex)
            {
                resultModel.Message = ex.Message;
                resultModel.IsSuccess = false;
                resultModel.ItemCount = 0;
                return resultModel;
            }
        }

        public async Task<GetFollowsListModel> GetFollowsList(UserFollowsSearchModel searchModel)
        {
            var userSet = await _userRepository.GetSet();

            var resultSet = userSet
                .Include(a => a.Followeds).ThenInclude(a => a.Follower)
                .Include(a => a.Followers).ThenInclude(a => a.Followed)
                .First(u => u.Id.Equals(searchModel.UserId));

            var followerList = new List<FollowInformationListItem>();
            var followedList = new List<FollowInformationListItem>();

            // aae1d398-55cf-4e7d-873b-b7f3f5f32e74
            resultSet.Followers.ForEach(f =>
            {
                var userName = f.Followed.Name + " " + f.Followed.Surname;
                var followId = f.Id;

                followedList.Add(new FollowInformationListItem { UserName = userName, FollowId = followId });
            });

            resultSet.Followeds.ForEach(f =>
            {
                var userName = f.Follower.Name + " " + f.Follower.Surname;
                var followId = f.Id;

                followerList.Add(new FollowInformationListItem { UserName = userName, FollowId = followId });
            });

            var result = new GetFollowsListModel
            {
                FollowedList = followedList,
                FollowerList = followerList,
                FollowedCount = followedList.Count,
                FollowerCount = followerList.Count,
                IsSuccess = true,
                ItemCount = followedList.Count + followerList.Count,
                Message = "Follows queried successfully"
            };

            return result;
        }

        //Gender
        //EventType
        //Age
        //event rating
        //Event attendance
        //Ticket Price
        //location
        //Day (weekend Or weekday)
        public async Task SuggestEventDataForML()
        {
            var resultModel = new MLSuggestEventDataListOutputModel();

            var ticketSet = await _ticketRepository.GetSet();

            var dataForML = ticketSet
                .Include(a => a.Owner).ThenInclude(o=>o.Ratings)
                .Include(a => a.Event).ThenInclude(b => b.EventType)
                .ToList();

            foreach (var data in dataForML)
            {
                var rating = data.Owner.Ratings.Find(a=>a.EventId.Equals(data.Event.Id));
                resultModel.ResultList.Add(new MLSuggestEventDataListItem()
                {
                    Age = data.Owner.Age,
                    eventType = data.Event.EventType.Name,
                    EventDate = data.Event.EventTime.ToString(),
                    Gender = data.Owner.Gender,
                    TicketPrice = (int)data.Price,
                    UserId = data.OwnerId,
                    UserEventRate = rating.Rate,
                    IsWeekend = 
                    data.Event.EventTime.DayOfWeek.ToString().Equals(DayOfWeek.Saturday) 
                    || 
                    data.Event.EventTime.DayOfWeek.ToString().Equals(DayOfWeek.Sunday)
                });
            }

            var qq = resultModel.ResultList.Select(a => a.IsWeekend).Where(b=>b.Equals(true)).Count();

            var xx = "asd";
            //using (StreamWriter writer = new StreamWriter("myfile.csv"))
            //{
            //    foreach (var data in resultModel.ResultList)
            //    {
            //        writer.WriteLine($"{data.UserId};{data.Age};{data.eventType};{data.EventDate};{data.Gender};{data.TicketPrice};{data.UserEventRate};{data.IsWeekend}");
            //    }
            //}
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

            if (!eventFilter.Radius.Equals(null))
            {
                predicateBuilder.And(a => a.Location.Latitude <= a.Location.Latitude + eventFilter.Radius
                && a.Location.Longitude <= a.Location.Longitude + eventFilter.Radius);
            }

            return predicateBuilder;
        }

        private static System.Linq.Expressions.Expression<Func<Organizator, bool>> OrganizatorFilterBuilder(OrganizatorSearchModel organizatorSearchModel)
        {
            var predicateBuilder = LinqKit.PredicateBuilder.New<Organizator>();

            if (!organizatorSearchModel.Name.IsNullOrEmpty())
            {
                predicateBuilder.And(a => a.Name.Equals(organizatorSearchModel.Name));
            }

            return predicateBuilder;
        }

        private static System.Linq.Expressions.Expression<Func<Event, bool>> EventLocationByFilter(LocationSearchModelForEvent locationSearchModel)
        {
            var predicateBuilder = LinqKit.PredicateBuilder.New<Event>();

            if (locationSearchModel.Latitude != null)
            {
                predicateBuilder.And(
                a => a.Location.Longitude + 0.4 > locationSearchModel.Longitude && a.Location.Longitude - 0.4 < locationSearchModel.Longitude);
            }

            if (locationSearchModel.Longitude == null)
            {
                predicateBuilder.And(
            a => a.Location.Latitude + 0.4 > locationSearchModel.Latitude && a.Location.Latitude - 0.4 < locationSearchModel.Latitude);
            }

            return predicateBuilder;
        }
    }
}