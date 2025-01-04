using Entities.Models;
using Shared;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges);
    
    Task<StudentDto> GetStudentAsync(Guid studentId, bool trackChanges);
    Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentForCreationDto);

    Task UpdateStudentAsync(Guid studentId, StudentForUpdateDto studentForUpdate, bool trackChanges);

    Task<(StudentForUpdateDto studentPatch, Student studentEntity)> GetStudentForPatch(Guid studentId, bool trackChanges);

    Task SavePatchedStudent(StudentForUpdateDto studentPatch, Student studentEntity);

    Task DeleteStudentAsync(Guid studentId);

}
