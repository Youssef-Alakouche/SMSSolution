using AutoMapper;
using SMSData.Models;
using SMSData.DTO;

namespace SMSData.Mapper;

public class EnrollmentProfiler : Profile
{
    public EnrollmentProfiler()
    {
        CreateMap<Enrollment, EnrollmentDto>();
        CreateMap<EnrollmentDto, Enrollment>();
    }
}