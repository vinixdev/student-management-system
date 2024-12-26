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

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, StudentService studentService, CourseService courseService, EnrollmentService enrollmentService)
    {

        _repository = repositoryManager;
        _logger = logger;

        _studentService = new Lazy<IStudentService>(() => new StudentService(_repository, _logger));
        _courseService = new Lazy<ICourseService>(() => new CourseService(_repository, _logger));
        _enrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService(_repository, _logger));

    }

    public IStudentService Student => _studentService.Value;
    public ICourseService Course => _courseService.Value;
    public IEnrollmentService Enrollment => _enrollmentService.Value;
}
