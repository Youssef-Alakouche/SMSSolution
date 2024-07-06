
// StudentId (Primary Key)
// FirstName
// LastName
// DateOfBirth
// Gender
// Email
// PhoneNumber
// Address
using SMSData.utility;

namespace SMSData.Models;

public class Student 
{
    public long StudentId {get; set;}
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public DateOnly DateOfBirth {get; set;}
    public Gender Gender {get; set;}
    public string? Email {get; set;}
    public string? PhoneNumber {get; set;}
    public string? Address {get; set;}

    // Relationship
    public ICollection<Enrollment>? Enrollments {get; set;}
}