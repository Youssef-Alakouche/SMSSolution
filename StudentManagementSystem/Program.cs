using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using SMS;
using SMSData.Mapper;
using SMSDomain.Data;
using SMSDomain.Services;

var builder = WebApplication.CreateBuilder(args);


// Json options pattern configuration
builder.Services.Configure<JsonOptions>(opts => {
    opts.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// autoMapper
// builder.Services.AddAutoMapper(typeof(MapperProfiler).Assembly);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<StudentProfiler>();
    cfg.AddProfile<CourseProfiler>();
    cfg.AddProfile<EnrollmentProfiler>();
});


builder.Services.AddControllers();

// Service Registration
builder.Services.DataServicesRegistration(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers(); 

// Seed data
DataContext dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
await SeedData.Seed(dbContext);

app.Run();
