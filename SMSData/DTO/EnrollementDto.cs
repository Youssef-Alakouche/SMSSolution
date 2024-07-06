using SMSData.Models;
using System.ComponentModel.DataAnnotations;

namespace SMSData.DTO;

public class EnrollmentDto {
    [Required]
    public long CourseId {get; set;}
    [Required]
    public long StudentId {get; set;}
    [Required]
    public DateOnly EnrollmentDate {get; set;}  

    public Enrollment ToEnrollment(){
        return new(){
            CourseId = CourseId,
            StudentId = StudentId,
            EnrollmentDate = EnrollmentDate
        };
    }
}