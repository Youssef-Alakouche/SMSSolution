using System.Collections;
using System.Text.Json;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SMS.Controllers;
using SMSData.Models;
using SMSDomain.Data;
using SMSData.utility;

namespace SMS.Test.Controllers.Test;

public class StudentController_Test
{
    [Fact]
    public void GetStudents_StudentsExist_ListOfStudent()
    {
        
        
        // Arrange
        var students = A.Fake<IList<Student>>();
       
        var context = new InMemoryContext(new DbContextOptions<InMemoryContext>());
        context.AddRange(students);
        
        StudentController student = new(context);

        // Act

        var sut = student.GetStudents();

        // Assert

        var okResult = Assert.IsType<OkObjectResult>(sut.Result);
        var result = Assert.IsAssignableFrom<IList<Student>>(okResult.Value);
        
        Assert.Equal(students, result);
    }

    [Fact]
    public void GetStudent_StudentExist_Student()
    {
        // Arrange
        Student student = new(){  
            FirstName= "Alice",
            LastName= "Johnson",
            DateOfBirth= new DateOnly(1998,03,12),
            Gender= Gender.Female,
            Email= "alice.johnson@example.com",
            PhoneNumber= "123-456-7890",
            Address= "123 Main Street, Cityville"};

        var context = new InMemoryContext(new DbContextOptions<InMemoryContext>());
        context.Students.Add(student);
        context.SaveChanges();
        
        // Act
        Student sut = context.Students.Single(s => s.StudentId == 1);

        // Assert
        
        Assert.Equal(student, sut);

    }

    [Fact]
    public void GetStudent_StudentNotExist_Null()
    {
        // Arrange
        IList<Student> students = A.Fake<IList<Student>>();
        var context = new InMemoryContext(new DbContextOptions<InMemoryContext>());
        context.AddRange(students);
        context.SaveChanges();
        
        
        // Act
        var sut = context.Students.SingleOrDefault(s => s.StudentId == Random.Shared.Next());

        // Assert
        Assert.Null(sut);

    }
    
}