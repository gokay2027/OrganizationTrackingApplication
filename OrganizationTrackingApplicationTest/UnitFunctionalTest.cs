using Entities.Domain;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using OrganizationTrackingApplicationData.GenericRepository.Concrete;

namespace OrganizationTrackingApplicationTest
{
    public class UnitFunctionalTest : TestDataContextFactory
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<EventType> _eventTypeRepository;
        
        public UnitFunctionalTest()
        {
            var context = GetContext();
            InitialData(context);
            _userRepository = new GenericRepository<User>(context);
            _eventTypeRepository = new GenericRepository<EventType>(context);
        }

        [Fact]
        public async Task AddUser()
        {
            await _userRepository.Insert(new User("asdsa", "adsa", "asdasd", "asadasad", false));
            var resultList = await _userRepository.GetAll();
            Assert.True(resultList.Count() > 0);
        }

        [Fact]
        public async Task GetAllEventTypes()
        {
            var eventTypes = await _eventTypeRepository.GetAll();
            Assert.NotEmpty(eventTypes);
        }
    }
}