using Entities.Domain;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using OrganizationTrackingApplicationData.GenericRepository.Concrete;

namespace OrganizationTrackingApplicationTest
{
    public class UnitFunctionalTest : TestDataContextFactory
    {
        private readonly ITestGenericRepository<User> _userRepository;

        public UnitFunctionalTest()
        {
            var context = GetContext();
            InitialData(context);
            _userRepository = new TestGenericRepository<User>(context);
        }

        [Fact]
        public async Task AddUser()
        {
            await _userRepository.Insert(new User("asdsa", "adsa", "asdasd", "asadasad", false));
            var resultList = await _userRepository.GetAll();
            Assert.True(resultList.Count() > 0);
        }
    }
}