using SMSData.Models;

namespace SMSData.DTO;

public class CourseDto {
    public string? Name {get; set;}
    public string? Description {get; set;}
    public int Credits {get; set;}

    // public ICollection<Enrollment>? enrollments {get; set;}

    public Course ToCourse(){
        Course course = new(){
            Name = Name,
            Description = Description,
            Credits = Credits,  
        };

        // if(enrollments is not null){

        //     course.enrollments = [];

        //     foreach(Enrollment enroll in enrollments)
        //         course.enrollments.Add(enroll);
        // }

        return course;
    } 
}