using System;
using Contracts;
using Entities.Models;

namespace Repository;

public sealed class RepositoryCourse : RepositoryBase<Course>, IRepositoryCourse
{
    public RepositoryCourse(RepositoryContext repositoryContext) : base(repositoryContext) { }
}
