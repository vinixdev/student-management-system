using Contracts;
using Service.Contracts;

namespace Service;

public class CourseService : ICourseService
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    public CourseService(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _repository = repositoryManager;
        _logger = logger;
    }
}
