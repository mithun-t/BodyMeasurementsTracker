using BodyMeasurementsTracker.Data;
using BodyMeasurementsTracker.Repositories;
using BodyMeasurementsTracker.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Register the AppDbContext for dependency injection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the Repository and Service layers
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBodyMeasurementRepository, BodyMeasurementRepository>();
builder.Services.AddScoped<BodyMeasurementService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers (this will be used to map your BodyMeasurementsController)
app.MapControllers();

app.Run();
