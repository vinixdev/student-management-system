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
}