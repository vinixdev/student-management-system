using Entities.Models;

namespace Contracts;

public interface IEnrollmentRepository
{
    void CreateEnrollment(Enrollment enrollment);
    Task<Enrollment?> GetEnrollmentAsync(Guid studentId, Guid courseId, bool trackChanges);
    Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(Guid studentId, bool trackChanges);
    Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(Guid courseId, bool trackChanges);
    void DeleteEnrollment(Enrollment enrollment);
    Task<Enrollment?> GetEnrollmentByStudentIdAndCourseIdAsync(Guid studentId, Guid courseId, bool trackChanges);
}
