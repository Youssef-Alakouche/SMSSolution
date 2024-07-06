using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SMSDomain.Data;
using SMSData.Models;
using SMSData.DTO;
using SMSDomain.Services;

namespace SMS.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class StudentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _repository;

    public StudentController(
        IStudentRepository repository,
        IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        IList<Student> students = await _repository.GetStudentsAsync();

        List<StudentDto> studentDtos = _mapper.Map<List<StudentDto>>(students);

        return Ok(studentDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        Student? student = _repository.GetStudent(id);


        if (student is null)
            return NotFound();

        _repository.GetStudentEnrollment(student);


        StudentDto? studentDto = _mapper.Map<StudentDto>(student);

        return Ok(studentDto);
    }

    [HttpPost]
    public IActionResult CreateStudent(StudentDto student)
    {
        _repository.CreateStudent(_mapper.Map<Student>(student));
        _repository.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveStudent(int id)
    {
        Student? student = _repository.GetStudent(id);

        if (student is null)
            return NotFound();

        _repository.RemoveStudent(student);
        _repository.SaveChanges();

        return Ok();
    }
}