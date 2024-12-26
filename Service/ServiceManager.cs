using System;
using Repository;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly RepositoryManager _repository;
    private readonly Lazy<IStudentService> _studentService;

    private readonly Lazy<ICourseService> _courseService;

    private readonly Lazy<IEnrollmentService> _enrollmentService;

    public ServiceManager(RepositoryManager repositoryManager, StudentService studentService, CourseService courseService, EnrollmentService enrollmentService)
    {

        _repository = repositoryManager;

        _studentService = new Lazy<IStudentService>(() => new StudentService());
        _courseService = new Lazy<ICourseService>(() => new CourseService());
        _enrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService());

    }

    public IStudentService Student => _studentService.Value;
    public ICourseService Course => _courseService.Value;
    public IEnrollmentService Enrollment => _enrollmentService.Value;
}
