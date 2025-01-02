using System;
using Entities.Models;

namespace Contracts;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
    
    Task<Student> GetStudentAsync(Guid studentId, bool trackChanges);

    void CreateStudent(Student student);
}
