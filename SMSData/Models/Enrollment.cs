// EnrollmentId (Primary Key)
// StudentId (Foreign Key referencing Student)
// CourseId (Foreign Key referencing Course)
// EnrollmentDate
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SMSData.Models;

public class Enrollment {
    public long EnrollmentId {get; set;}
    public long CourseId {get; set;}
    public long StudentId {get; set;}
    public DateOnly EnrollmentDate {get; set;}  

    // Relationships

    public Student? student {get; set;}
    public Course? course {get; set;}
}