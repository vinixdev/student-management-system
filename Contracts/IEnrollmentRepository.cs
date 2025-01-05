using System;
using Entities.Models;

namespace Contracts;

public interface IEnrollmentRepository
{
    void CreateEnrollment(Enrollment enrollment);
    Task<Enrollment>? GetEnrollment(Guid enrollmentId);
    void DeleteEnrollment(Enrollment enrollment);
}
