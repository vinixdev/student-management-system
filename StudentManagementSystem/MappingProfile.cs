using System.Runtime.InteropServices.JavaScript;
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
        CreateMap<Course, CourseDto>().ForMember(c => c.CreatedAt, opt => opt.MapFrom(c => c.CreatedAt.ToString("yyyy-MM-dd")));
        
        CreateMap<Enrollment, EnrollmentDto>();

        CreateMap<StudentForUpdateDto, Student>().ReverseMap();
        CreateMap<StudentForCreationDto, Student>();

        CreateMap<CourseForCreationDto, Course>();
        CreateMap<CourseForUpdateDto, Course>().ReverseMap();

        CreateMap<EnrollmentForCreationDto, Enrollment>();
    }
}
