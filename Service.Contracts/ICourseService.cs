using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAllCourses(bool trackChanges);
    Task<CourseDto> GetCourseAsync(Guid courseId, bool trackChanges);
    Task<CourseDto> CreateCourseAsync(CourseForCreationDto courseForCreationDto);
    Task DeleteCourseAsync(Guid courseId);
    Task<CourseDto> UpdateCourseAsync(Guid courseId, CourseForUpdateDto courseForUpdateDto, bool trackChanges);
    Task<(CourseForUpdateDto courseForUpdateDto, Course courseEntity)> GetCourseForPatchAsync(Guid courseId, bool trackChanges);
    Task SavePatchedCourseAsync(CourseForUpdateDto courseForUpdateDto, Course courseEntity);
    Task<IEnumerable<StudentDto>> GetCourseStudentsAsync(Guid courseId, bool trackChanges);
}
