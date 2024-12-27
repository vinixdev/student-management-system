using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class EnrollmentService : IEnrollmentService
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    private readonly IMapper _mapper;

    public EnrollmentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repository = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }
}
