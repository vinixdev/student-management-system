using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjecs;

namespace StudentMangementSystem;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<Course, CourseDto>();
        CreateMap<Enrollment, EnrollmentDto>();
    }
}
