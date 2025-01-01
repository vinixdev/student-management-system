using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IStudentService> _studentService;
    private readonly Lazy<ICourseService> _courseService;
    private readonly Lazy<IEnrollmentService> _enrollmentService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {


        _studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, logger, mapper));
        _courseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager, logger, mapper));
        _enrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService(repositoryManager, logger, mapper));

    }

    public IStudentService Student => _studentService.Value;
    public ICourseService Course => _courseService.Value;
    public IEnrollmentService Enrollment => _enrollmentService.Value;
}
