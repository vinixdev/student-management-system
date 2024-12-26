using System;

namespace Service.Contracts;

public interface IServiceManager
{
    IStudentService Student { get; }
    IEnrollmentService Enrollment { get; }
    ICourseService Course { get; }
}
