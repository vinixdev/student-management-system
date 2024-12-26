using System;
using Contracts;
using Entities.Models;

namespace Repository;

public class RepositoryEnrollment : RepositoryBase<Enrollment>, IRepositoryEntrollment
{
    public RepositoryEnrollment(RepositoryContext repositoryContext) : base(repositoryContext) { }
}
