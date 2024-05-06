using Entities.Domain;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using OrganizationTrackingApplicationData.GenericRepository.Concrete;

namespace OrganizationTrackingApplicationTest
{
    public class UnitFunctionalTest : TestDataContextFactory
    {
        private readonly ITestGenericRepository<User> _userRepo;

        public UnitFunctionalTest()
        {
            var context = GetContext();
            InitialData(context);
            _userRepo = new TestGenericRepository<User>(context);
        }

        [Fact]
        public async Task AddUser()
        {
            await _userRepo.Insert(new User("asdsa", "adsa", "asdasd", "asadasad", false));
            var resultList = await _userRepo.GetAll();
            Assert.True(resultList.Count() > 0);
        }
    }
}