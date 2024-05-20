using Entities.Domain;
using OrganizationTrackingApplicationApi.Application.DummyCommand;
using OrganizationTrackingApplicationApi.Application.Query;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationData;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using OrganizationTrackingApplicationData.GenericRepository.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrganizationTrackingApplicationDbContext>();

builder.Services.AddTransient<IOrganizationTrackingApplicationQuery, OrganizationTrackingApplicationQuery>();
builder.Services.AddTransient<IDummyCommand, DummyCommand>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();