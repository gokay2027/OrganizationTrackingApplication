using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using OrganizationTrackingApplicationData;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using OrganizationTrackingApplicationData.GenericRepository.Concrete;

namespace OrganizationTrackingApplicationTest
{
    public class UnitTest1
    {

        private OrganizationTrackingApplicationDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<OrganizationTrackingApplicationDbContext>().
                UseSqlite("Data Source = nameOfYourDatabase.db")
                .Options;

            var db = new OrganizationTrackingApplicationDbContext(options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public async void Test1()
        {
            using var db = GetContext();
        }
    }
}