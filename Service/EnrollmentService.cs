using Contracts;
using Service.Contracts;

namespace Service;

public class EnrollmentService : IEnrollmentService
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    public EnrollmentService(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _repository = repositoryManager;
        _logger = logger;
    }
}
