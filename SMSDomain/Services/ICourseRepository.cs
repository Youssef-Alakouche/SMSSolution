using SMSData.Models;

namespace SMSDomain.Services;

public interface ICourseRepository
{
    IList<Course> GetCourses();
    Task<IList<Course>> GetCoursesAsync();
    
    Course? GetCourse(int id);
    Task<Course?> GetCourseAsync(int id);

    void LoadEnrollment(Course course);

    void AddCourse(Course course);
    Task AddCourseAsync(Course course);

    void RemoveCourse(Course course);

    void SaveChanges();
    Task SaveChangesAsync();
}