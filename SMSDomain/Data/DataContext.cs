
using Microsoft.EntityFrameworkCore;
using SMSData.Models;

namespace SMSDomain.Data;

public class DataContext : DbContext {
    
    public DataContext(DbContextOptions<DataContext> opts) : base(opts){}

    // entities
    public DbSet<Student> Students {get; set;}
    public DbSet<Course> Courses {get; set;}
    public DbSet<Enrollment> Enrollments {get; set;}
    
}