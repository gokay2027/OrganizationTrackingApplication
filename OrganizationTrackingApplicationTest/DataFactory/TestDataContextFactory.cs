using Microsoft.EntityFrameworkCore;
using OrganizationTrackingApplicationData;

/// <summary>
/// Using sqlite, it provides us relations between entities
/// it is important that context should be used once actually the
/// technique is creating the connection to inMemory database second,
/// using context the in memory connection option should be used on the context,
/// the context provides us the relations and entities. So we have a good options for
/// both test and development databases. Hereby, thanks to TestContextFactory, we have both
/// sqlite test database and except that, we have a normal database which comes from
/// MSSQL
/// </summary>
public class TestDataContextFactory
{
    /// <summary>
    /// Creates context for testing using sqlite
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Initial in memory data for testing
    /// </summary>
    /// <param name="context"></param>
    protected void InitialData(OrganizationTrackingApplicationDbContext context)
    {
        context.Users.AddAsync(new Entities.Domain.User("Kral", "Şakir", "gokay123@gmail.com", "1234", true));
        context.Users.AddAsync(new Entities.Domain.User("Polat", "Alemdar", "mehmet123@gmail.com", "12345", true));
        context.Users.AddAsync(new Entities.Domain.User("Yakışıklı", "Güvenlik", "cihan123@gmail.com", "123456", true));

        context.SaveChangesAsync();
    }
}