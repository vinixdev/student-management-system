using System;
using Contracts;
using Entities.Models;

namespace Repository;

public sealed class CoruseRipository : RepositoryBase<Course>, ICoruseRepository
{
    public CoruseRipository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public async Task<IEnumerable<Course>> GetAllCourses()
    {
        
    }
}
