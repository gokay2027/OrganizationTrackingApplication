using Microsoft.EntityFrameworkCore;
using OrganizationTrackingApplicationData;

public class TestDataContextFactory
{

    protected OrganizationTrackingApplicationDbContext GetContext()
    {
        var options = new DbContextOptionsBuilder<OrganizationTrackingApplicationDbContext>().
            UseSqlite("Data Source = nameOfYourDatabase.db")
            .Options;

        var db = new OrganizationTrackingApplicationDbContext(options);

        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        return db;
    }

    protected void InitialData(OrganizationTrackingApplicationDbContext context)
    {
        context.Users.AddAsync(new Entities.Domain.User("Gokay", "Dinç", "gokay123@gmail.com", "1234", true));
        context.SaveChangesAsync();
    }
}