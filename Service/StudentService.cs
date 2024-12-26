using Contracts;
using Service.Contracts;

namespace Service;

public class StudentService : IStudentService
{

    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    public StudentService(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _repository = repositoryManager;
        _logger = logger;
    }
}
