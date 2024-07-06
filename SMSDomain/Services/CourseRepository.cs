using Microsoft.EntityFrameworkCore;
using SMSData.Models;
using SMSDomain.Data;

namespace SMSDomain.Services;

public class CourseRepository : ICourseRepository
{

    private readonly DataContext _context;

    public CourseRepository(DataContext context)
    {
        _context = context;
    }
    
    public IList<Course> GetCourses()
    {
        IList<Course> courses = _context.Courses.ToList();

        return courses;
    }

    public async Task<IList<Course>> GetCoursesAsync()
    {
        IList<Course> courses = await _context.Courses.ToListAsync();

        return courses;
    }

    public Course? GetCourse(int id)
    {
        Course? course = _context.Courses.FirstOrDefault(c => c.CourseId == id);

        return course;
    }

    public async Task<Course?> GetCourseAsync(int id)
    {
        Course? course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);

        return course;
    }

    public void LoadEnrollment(Course course)
    {
        _context.Entry(course).Collection(c => c.enrollments!).Load();

        foreach(Enrollment enroll in course.enrollments!)
            enroll.course = null;
    }

    public void AddCourse(Course course)
    {
        _context.Courses.Add(course);
    }

    public async Task AddCourseAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
    }

    public void RemoveCourse(Course course)
    {
        _context.Courses.Remove(course);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}