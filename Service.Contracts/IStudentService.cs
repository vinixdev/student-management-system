using System;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudents(bool trackChanges);
}
