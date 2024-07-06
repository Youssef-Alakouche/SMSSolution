using SMSData.DTO;
using SMSData.Models;

namespace SMSDomain.Services;

public interface IStudentRepository
{
    IList<Student> GetStudents();
    Task<IList<Student>> GetStudentsAsync();
    
    Student? GetStudent(int id);
    Task<Student?> GetStudentAsync(int id);

    void GetStudentEnrollment(Student student);
    
    void CreateStudent(Student student);
    Task CreateStudentAsync(Student student);

    void RemoveStudent(Student student);
    void SaveChanges();
    Task SaveChangesAsync();
}