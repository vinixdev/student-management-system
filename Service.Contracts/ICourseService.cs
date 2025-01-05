using System;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAllCourses(bool trackChanges);
    Task<CourseDto> GetCourseAsync(Guid courseId, bool trackChanges);
}
