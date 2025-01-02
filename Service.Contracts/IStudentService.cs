using System;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges);
}
