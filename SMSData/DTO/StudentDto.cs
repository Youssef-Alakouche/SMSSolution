
using SMSData.utility;
using SMSData.Models;

namespace SMSData.DTO;

public class StudentDto {
    
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public DateOnly DateOfBirth {get; set;}
    public Gender Gender {get; set;}
    public string? Email {get; set;}
    public string? PhoneNumber {get; set;}
    public string? Address {get; set;}

    public ICollection<Enrollment>? enrollments {get; set;}

    public Student ToStudent(){
        Student student = new(){
            FirstName = FirstName,
            LastName = LastName,
            DateOfBirth = DateOfBirth,
            Gender = Gender,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Address = Address
        };

        // if(enrollments is not null){

        //     student.Enrollments = [];

        //     foreach(Enrollment enroll in enrollments)
        //         student.Enrollments.Add(enroll);
        // }


        return student;
    }
}