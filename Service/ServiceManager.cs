using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly Lazy<IStudentService> _studentService;
    private readonly Lazy<ICourseService> _courseService;
    private readonly Lazy<IEnrollmentService> _enrollmentService;

    private readonly IMapper _mapper;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, StudentService studentService, CourseService courseService, EnrollmentService enrollmentService, IMapper mapper)
    {

        _repository = repositoryManager;
        _logger = logger;
        _mapper = mapper;

        _studentService = new Lazy<IStudentService>(() => new StudentService(_repository, _logger, _mapper));
        _courseService = new Lazy<ICourseService>(() => new CourseService(_repository, _logger, _mapper));
        _enrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService(_repository, _logger, _mapper));

    }

    public IStudentService Student => _studentService.Value;
    public ICourseService Course => _courseService.Value;
    public IEnrollmentService Enrollment => _enrollmentService.Value;
}
