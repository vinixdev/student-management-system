using AutoMapper;
using Contracts;
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
}