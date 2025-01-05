using System;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAllCourses(bool trackChanges);
    Task<CourseDto> GetCourse(Guid courseId, bool trackChanges);
}
