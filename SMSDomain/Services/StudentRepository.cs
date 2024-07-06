using Microsoft.EntityFrameworkCore;
using SMSData.DTO;
using SMSData.Models;
using SMSDomain.Data;


namespace SMSDomain.Services;

public class StudentRepository : IStudentRepository
{
    private readonly DataContext _context;

    public StudentRepository(DataContext context)
    {
        _context = context;
    }

    public IList<Student> GetStudents()
    {
        List<Student> students = _context.Students.ToList();

        return students;
    }

    public async Task<IList<Student>> GetStudentsAsync()
    {
        List<Student> students = await _context.Students.ToListAsync();

        return students;
    }

    public Student? GetStudent(int id)
    {
        Student? student = _context.Students.FirstOrDefault(s => s.StudentId == id);

        return student;
    }

    public async Task<Student?> GetStudentAsync(int id)
    {
        Student? student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);

        return student;
    }

    public void GetStudentEnrollment(Student student)
    {
        _context.Entry(student).Collection(s => s.Enrollments!).Load();

        foreach (Enrollment enroll in student.Enrollments!)
        {
            _context.Entry(enroll).Reference(s => s.course).Load();

            // this for preventing json cyclic object problem
            // this should be called at end
            // no statment or expression that hits the change tracker should be called after this.

            enroll.student = null;
            if (enroll.course is not null)
                enroll.course.enrollments = null;

            // this will make enrollment property empty
            // because it hits change tracker
            // EntityState state = _context.Entry(enroll).State;
        }
    }

    public void CreateStudent(Student student)
    {
        _context.Students.Add(student);
    }

    public async Task CreateStudentAsync(Student student)
    {
        await _context.Students.AddAsync(student);
    }

    public void RemoveStudent(Student student)
    {
        _context.Students.Remove(student);
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