using SMSData.Models;

namespace SMSDomain.Services;

public interface IEnrollmentRepository
{
    IList<Enrollment> GetEnrollments();
    Task<IList<Enrollment>> GetEnrollmentsAsync();

    Enrollment? GetEnrollment(int id);
    Task<Enrollment?> GetEnrollmentAsync(int id);

    void AddEnrollment(Enrollment enrollment);
    Task AddEnrollmentAsync(Enrollment enrollment);

    void RemoveEnrollment(Enrollment enrollment);

    void SaveChanges();
    Task SaveChangesAsync();
} 
