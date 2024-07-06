
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SMSDomain.Data;
using SMSData.Models;
using SMSData.DTO;
using SMSDomain.Services;

namespace SMS.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class EnrollmentController: ControllerBase
{
    private DataContext _context {get; set;}
    private readonly IEnrollmentRepository _repository;
    private readonly IMapper _mapper;
    
    public EnrollmentController(DataContext dataContext, 
        IEnrollmentRepository repository,
        IMapper mapper){
        _context = dataContext;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetEnrollments(){
        IList<Enrollment> enrolls = _repository.GetEnrollments();

        return Ok(enrolls);
    }

    [HttpGet("{id}")]
    public IActionResult GetEnrollment(int id)
    {
        Enrollment? enroll = _repository.GetEnrollment(id);

        if(enroll is null)
            return NotFound();
        
        return Ok(enroll);
    }

    [HttpPost]
    public IActionResult CreateEnrollment(EnrollmentDto enrollmentDto){
        _repository.AddEnrollment(_mapper.Map<Enrollment>(enrollmentDto));
        _repository.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveEnrollment(int id)
    {
        Enrollment? enroll = _repository.GetEnrollment(id);

        if(enroll is null)
            return NotFound();

        _repository.RemoveEnrollment(enroll);
        _repository.SaveChanges();

        return Ok();
    }
}