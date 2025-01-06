using Entities.Models;

namespace Contracts;

public interface IEnrollmentRepository
{
    void CreateEnrollment(Enrollment enrollment);
    Task<Enrollment?> GetEnrollmentAsync(Guid studentId, Guid courseId, bool trackChanges);
    Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(Guid studentId, bool trackChanges);
    void DeleteEnrollment(Enrollment enrollment);
    

    // TODO: create route for courses to get students they enroll
}
