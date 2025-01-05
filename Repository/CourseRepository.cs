using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public sealed class CoruseRipository : RepositoryBase<Course>, ICoruseRepository
{
    public CoruseRipository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public async Task<IEnumerable<Course>> GetAllCourses(bool trackChanges)
    {
        var courses = FindAll(trackChanges);
        return await courses.ToListAsync();
    }
}
