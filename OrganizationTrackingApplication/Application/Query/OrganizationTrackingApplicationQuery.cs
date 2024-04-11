using Entities.Domain;
using LinqKit;
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
            var eventSet = await _eventRepository.GetSet();
            var allIncludedEventList = eventSet.Include(a => a.Organizator)
                .Include(a => a.EventType)
                .Include(a => a.Location)
                .OrderBy(a => a.CreatedDate)
                .ToList();

            var eventListModel = new EventListModel();

            foreach (var item in allIncludedEventList)
            {
                eventListModel.EventList.Add(new EventListItem
                {
                    EventTime = item.EventTime,
                    EventTypeName = item.EventType.Name,
                    IsCompleted = item.IsCompleted,
                    Name = item.Name,
                    OrganizatorName = item.Organizator.Name,
                    LocationAdress = item.Location.FormattedName,
                });
            }

            return eventListModel;
        
        }

        public async Task<EventListModel> GetEventsByFilter(EventSearchModel eventFilter)
        {


            var filter = EventFilterBuilder(eventFilter);

            var eventSet = await _eventRepository.GetSet();
            var allIncludedEventList = eventSet.Include(a => a.Organizator)
                .Include(a => a.EventType)
                .Include(a => a.Location)
                .OrderBy(a => a.CreatedDate).Where(filter)
                .ToList();

            var eventListModel = new EventListModel();

            foreach (var item in allIncludedEventList)
            {
                eventListModel.EventList.Add(new EventListItem
                {
                    EventTime = item.EventTime,
                    EventTypeName = item.EventType.Name,
                    IsCompleted = item.IsCompleted,
                    Name = item.Name,
                    OrganizatorName = item.Organizator.Name,
                    LocationAdress = item.Location.FormattedName,
                });
            }
            
            return eventListModel;
        }

        public Task<UserInformationModel> GetUserInformation(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserListModel> GetUserListByFilter(UserListSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public Task<LoginUserResultModel> LoginUser(LoginUserModel loginModel)
        {
            throw new NotImplementedException();
        }

        private static System.Linq.Expressions.Expression<Func<Event, bool>> EventFilterBuilder(EventSearchModel eventFilter)
        {
            var predicateBuilder = LinqKit.PredicateBuilder.True<Event>();

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