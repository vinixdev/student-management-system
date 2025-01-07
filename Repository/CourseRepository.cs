using System;
using Contracts;
using Entities.Exceptions;
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

    public async Task<Course?> GetCourseAsync(Guid courseId, bool trackChanges)
    {
        return await FindByCondition(c => c.Id.Equals(courseId), trackChanges).SingleOrDefaultAsync();
    }

    public void CreateCourse(Course course) => Create(course);
    public void DeleteCourse(Course course) => Delete(course);

    public async Task<IEnumerable<Course>> GetCoursesByIdsAsync(IEnumerable<Guid> courseIds, bool trackChanges) =>
        await FindByCondition(c => courseIds.Contains(c.Id), trackChanges).ToListAsync();

}
