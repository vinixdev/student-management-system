using System;
using Shared.DataTransferObjecs;

namespace Service.Contracts;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudents(bool trackChanges);
}
