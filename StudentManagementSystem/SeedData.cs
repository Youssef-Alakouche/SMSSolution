
using Microsoft.EntityFrameworkCore;

using SMSDomain.Data;
using SMSData.Models;
using SMSData.utility;

namespace SMS;

public class SeedData {

 
    public static async Task Seed(DataContext dataContext){

        if(
            dataContext.Students.Count() == 0 &&
            dataContext.Courses.Count() == 0
            
        ){
            dataContext.Database.Migrate();
            List<Student> students = 
            [
                new(){  FirstName= "Alice",
                        LastName= "Johnson",
                        DateOfBirth= new DateOnly(1998,03,12),
                        Gender= Gender.Female,
                        Email= "alice.johnson@example.com",
                        PhoneNumber= "123-456-7890",
                        Address= "123 Main Street, Cityville"},
                new(){  FirstName= "Bob",
                        LastName= "Smith",
                        DateOfBirth= new DateOnly(1997,07,22),
                        Gender= Gender.Male,
                        Email= "bob-smith@example.com",
                        PhoneNumber= "143-406-4890",
                        Address= "456 Elm Street, Townsville"},
                new(){  FirstName= "Charlie",
                        LastName= "brown",
                        DateOfBirth= new DateOnly(1998,03,12),
                        Gender= Gender.Male,
                        Email= "charlie.brown@example.com",
                        PhoneNumber= "123-456-7890",
                        Address= "789 Oak Street, Villageton"},
                new(){  FirstName= "Diana",
                        LastName= "Williams",
                        DateOfBirth= new DateOnly(1998,03,12),
                        Gender= Gender.Female,
                        Email= "diana.williams@example.com",
                        PhoneNumber= "123-456-7890",
                        Address= "321 Pine Street, Hamletville"},
            ];

            List<Course> courses =
            [
                new(){       
                    Name= "Introduction to Programming",
                    Description= "This course covers the basics of programming concepts and syntax.",
                    Credits= 3
                },
                new(){
                    Name= "Web Development Fundamentals",
                    Description= "Learn the fundamentals of web development including HTML, CSS, and JavaScript.",
                    Credits= 4
                },
                new(){     
                    Name= "Database Management Systems",
                    Description= "Explore concepts and techniques for managing and querying databases.",
                    Credits= 3
                },
                new(){
                    Name= "Software Engineering Principles",
                    Description= "Gain an understanding of software engineering principles and best practices.",
                    Credits= 3
                }
            
            ];

            await dataContext.AddRangeAsync(students);
            await dataContext.AddRangeAsync(courses);

            await dataContext.SaveChangesAsync();

            List<Enrollment> enrollments = 
            [
                new(){
                StudentId= 1,
                CourseId= 1,
                EnrollmentDate= new DateOnly(2024,02,15)
                },
                new (){
                StudentId= 2,
                CourseId= 2,
                EnrollmentDate= new DateOnly(2024,02,16)
                },
                new(){
                StudentId= 3,
                CourseId= 3,
                EnrollmentDate= new DateOnly(024,02,17)
                },
                new(){
                StudentId= 4,
                CourseId= 4,
                EnrollmentDate= new DateOnly(2024,02,18)
                }
            ];

            
            await dataContext.AddRangeAsync(enrollments);

            await dataContext.SaveChangesAsync();

        }

    }
}