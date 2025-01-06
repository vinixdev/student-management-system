using System;
using Contracts;
using Entities.Models;

namespace Repository;

public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    public void CreateEnrollment(Enrollment enrollment) => Create(enrollment);
    public async Task<Enrollment>? GetEnrollment(Guid studentId, Guid courseId)
    {
        throw new NotImplementedException();    
    }
    public void DeleteEnrollment(Enrollment enrollment)
    {
        throw new NotImplementedException();
    }
}
