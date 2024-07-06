using Microsoft.EntityFrameworkCore;
using SMSData.Models;
using SMSDomain.Data;

namespace SMSDomain.Services;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly DataContext _context;

    public EnrollmentRepository(DataContext context)
    {
        _context = context;
    }
    
    public IList<Enrollment> GetEnrollments()
    {
        IList<Enrollment> enrollments = _context.Enrollments.ToList();

        return enrollments;
    }

    public async Task<IList<Enrollment>> GetEnrollmentsAsync()
    {
        IList<Enrollment> enrollments = await _context.Enrollments.ToListAsync();

        return enrollments;
    }

    public Enrollment? GetEnrollment(int id)
    {
        Enrollment? enrollment = _context.Enrollments.FirstOrDefault(e => e.EnrollmentId == id);

        return enrollment;
    }

    public async Task<Enrollment?> GetEnrollmentAsync(int id)
    {
        Enrollment? enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == id);

        return enrollment;
    }

    public void AddEnrollment(Enrollment enrollment)
    {
        _context.Add(enrollment);
    }

    public async Task AddEnrollmentAsync(Enrollment enrollment)
    {
        await _context.AddAsync(enrollment);
    }

    public void RemoveEnrollment(Enrollment enrollment)
    {
        _context.Remove(enrollment);
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