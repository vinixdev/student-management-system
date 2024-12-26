using System;
using Contracts;
using Entities.Models;

namespace Repository;

public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
}
