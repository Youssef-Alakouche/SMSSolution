using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SMSDomain.Data;
using SMSData.Models;
using SMSData.DTO;
using SMSDomain.Services;

namespace SMS.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CourseController : ControllerBase
{
    
    private readonly ICourseRepository _repository;
    private readonly IMapper _mapper;
    
    public CourseController(ICourseRepository repository, IMapper mapper)
    {
      
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        IList<Course> courses = await _repository.GetCoursesAsync();

        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourse(int id)
    {
        Course? course = await _repository.GetCourseAsync(id);
        
        if (course is null)
            return NotFound();

        _repository.LoadEnrollment(course);

        return Ok(course);
    }

    [HttpPost]
    public IActionResult CreateCourse(CourseDto course)
    {
        _repository.AddCourse(_mapper.Map<Course>(course));
        _repository.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveCourse(int id)
    {
        Course? course = _repository.GetCourse(id);

        if (course is null)
            return NotFound();

        _repository.RemoveCourse(course);
        _repository.SaveChanges();

        return Ok();
    }
}