using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjecs;

namespace StudentManagementSystem;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<Course, CourseDto>();
        CreateMap<Enrollment, EnrollmentDto>();
    }
}
