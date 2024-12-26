using System;

namespace Contracts;

public interface IRepositoryManager
{
    void Save();
    ICoruseRepository Course { get; }
    IEnrollmentRepository Entrollment { get; }
    IStudentRepository Student { get; }
}
