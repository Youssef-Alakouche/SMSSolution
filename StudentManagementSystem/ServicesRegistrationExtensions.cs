using Microsoft.EntityFrameworkCore;
using SMS.Controllers;
using SMSDomain;
using SMSDomain.Data;
using SMSDomain.Services;

namespace SMS;

public static class ServicesRegisterationExtensions
{
    public static void DataServicesRegistration(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        
        // Repository services
        serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
        serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
        serviceCollection.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        
        // DbContext
        serviceCollection.AddDbContext<DataContext>(Opts =>
        {
            Opts.UseSqlServer(
                configuration.GetConnectionString("sqlServer")
            );
        });
        
    }
    
    
    
    
}    

