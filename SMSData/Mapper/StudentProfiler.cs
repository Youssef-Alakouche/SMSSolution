using AutoMapper;
using SMSData.Models;
using SMSData.DTO;

namespace SMSData.Mapper;

public class StudentProfiler : Profile
{
    public StudentProfiler()
    {
       
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
        
    }
}