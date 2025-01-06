using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    public void CreateEnrollment(Enrollment enrollment) => Create(enrollment);
    public async Task<Enrollment?> GetEnrollmentAsync(Guid studentId, Guid courseId, bool trackChanges)
    {
        return await FindByCondition(e => e.StudentId.Equals(studentId) && e.CourseId.Equals(courseId), trackChanges).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(Guid studentId, bool trackChanges)
    {
        return await FindByCondition(e => e.StudentId.Equals(studentId), trackChanges).ToListAsync();
    }

    public void DeleteEnrollment(Enrollment enrollment) => Delete(enrollment);
}
