using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges);
    
    Task<StudentDto> GetStudentAsync(Guid studentId, bool trackChanges);
    Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentForCreationDto);

    Task UpdateStudentAsync(StudentForModificationDto studentForModificationDto);

    Task DeleteStudentAsync(Guid studentId);

}
