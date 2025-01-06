using System;
using Entities.Models;

namespace Contracts;

public interface IEnrollmentRepository
{
    void CreateEnrollment(Enrollment enrollment);
    Task<Enrollment?> GetEnrollmentAsync(Guid studentId, Guid courseId, bool trackChanges);
    void DeleteEnrollment(Enrollment enrollment);
    

    // TODO: create route for students to get courses they enroll
    // TODO: create route for courses to get students they enroll
}
