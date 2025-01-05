using System;
using Contracts;
using Entities.Models;

namespace Repository;

public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    public void CreateEnrollment(Enrollment enrollment) => Create(enrollment);
    public Task<Enrollment>? GetEnrollment(Guid enrollmentId)
    {
        throw new NotImplementedException();
    }

    public void DeleteEnrollment(Enrollment enrollment)
    {
        throw new NotImplementedException();
    }
}
