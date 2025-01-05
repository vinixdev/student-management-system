using System;
using Entities.Models;

namespace Contracts;

public interface ICoruseRepository
{
    Task<IEnumerable<Course>> GetAllCourses(bool trackChanges);
    Task<Course?> GetCourseAsync(Guid courseId, bool trackChanges);
    void CreateCourse(Course course);
    void DeteleCourse(Course course);
}
