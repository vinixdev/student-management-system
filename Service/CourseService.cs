using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class CourseService : ICourseService
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CourseService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repository = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }
}
