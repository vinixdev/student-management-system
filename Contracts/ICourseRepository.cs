using System;
using Entities.Models;

namespace Contracts;

public interface ICoruseRepository
{
    Task<IEnumerable<Course>> GetAllCourses(bool trackChanges);
    Task<Course?> GetCourseAsync(Guid courseId, bool trackChanges);
    void CreateCourse(Course course);
    void DeleteCourse(Course course);
    Task<IEnumerable<Course>> GetCoursesByIdsAsync(IEnumerable<Guid> courseIds, bool trackChanges);
}
