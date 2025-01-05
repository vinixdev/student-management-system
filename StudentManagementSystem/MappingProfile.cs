using AutoMapper;
using Entities.Models;
using Shared;
using Shared.DataTransferObjects;

namespace StudentManagementSystem;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<Course, CourseDto>();
        CreateMap<Enrollment, EnrollmentDto>();

        CreateMap<StudentForUpdateDto, Student>().ReverseMap();
        CreateMap<StudentForCreationDto, Student>();

        CreateMap<CourseForCreationDto, CourseDto>();
    }
}
