using AutoMapper;
using SMSData.DTO;
using SMSData.Models;

namespace SMSData.Mapper;

public class CourseProfiler : Profile
{
    public CourseProfiler()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<CourseDto, Course>();
    }
}