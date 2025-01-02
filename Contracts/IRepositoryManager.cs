using System;

namespace Contracts;

public interface IRepositoryManager
{
    Task SaveAsync();
    ICoruseRepository Course { get; }
    IEnrollmentRepository Entrollment { get; }
    IStudentRepository Student { get; }
}
