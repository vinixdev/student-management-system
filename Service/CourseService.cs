using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class CourseService : ServiceBase, ICourseService
{
    public CourseService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper) : base(logger,
        repositoryManager, mapper) { }

    public async Task<IEnumerable<CourseDto>> GetAllCourses(bool trackChanges)
    {
        var courseEntities = await Repository.Course.GetAllCourses(trackChanges);

        var courses = Mapper.Map<IEnumerable<CourseDto>>(courseEntities);

        return courses;
    }

    public async Task<CourseDto> GetCourseAsync(Guid courseId, bool trackChanges)
    {
        var courseEntity = await TryGetEntityAsync<Course>(courseId, trackChanges);

        var courseDto = Mapper.Map<CourseDto>(courseEntity);

        return courseDto;
    }

    public async Task<CourseDto> CreateCourseAsync(CourseForCreationDto courseForCreationDto)
    {
        var courseEntity = Mapper.Map<Course>(courseForCreationDto);
        
        Repository.Course.CreateCourse(courseEntity);
        
        await Repository.SaveAsync();

        var courseDto = Mapper.Map<CourseDto>(courseEntity);

        return courseDto;
    }

    public async Task DeleteCourseAsync(Guid courseId)
    {
        var courseEntity = await TryGetEntityAsync<Course>(courseId, false);
        
        Repository.Course.DeleteCourse(courseEntity);

        await Repository.SaveAsync();
    }

    public async Task<CourseDto> UpdateCourseAsync(Guid courseId, CourseForUpdateDto courseForUpdateDto, bool trackChanges)
    {
        var courseEntity = await TryGetEntityAsync<Course>(courseId, trackChanges);

        Mapper.Map(courseForUpdateDto, courseEntity);

        await Repository.SaveAsync();

        var courseDto = Mapper.Map<CourseDto>(courseEntity);

        return courseDto;
    }

    public async Task<(CourseForUpdateDto courseForUpdateDto, Course courseEntity)> GetCourseForPatchAsync(Guid courseId, bool trackChanges)
    {
        var courseEntity = await TryGetEntityAsync<Course>(courseId, trackChanges);

        var courseForUpdate = Mapper.Map<CourseForUpdateDto>(courseEntity);

        return (courseForUpdate, courseEntity);
    }

    public async Task SavePatchedCourseAsync(CourseForUpdateDto courseForUpdateDto, Course courseEntity)
    {
        Mapper.Map(courseForUpdateDto, courseEntity);
        await Repository.SaveAsync();
    }

    public async Task<IEnumerable<StudentDto>> GetCourseStudentsAsync(Guid courseId, bool trackChanges)
    {
        await TryGetEntityAsync<Course>(courseId, trackChanges);

        var enrollments = await Repository.Entrollment.GetEnrollmentsByCourseIdAsync(courseId, trackChanges);

        var studentIds = enrollments.Select(e => e.StudentId).ToList();

        var studentEntities = await Repository.Student.GetStudentsByIdsAsync(studentIds, trackChanges);

        var studentsToReturn = Mapper.Map<IEnumerable<StudentDto>>(studentEntities);

        return studentsToReturn;
    }
}