using System;
using Contracts;
using Entities.Models;

namespace Repository;

public sealed class RepositoryStudent : RepositoryBase<Student>, IRepositoryStudent
{

    public RepositoryStudent(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
