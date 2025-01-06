using System;
using Entities.Models;

namespace Contracts;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
    
    Task<Student?> GetStudentAsync(Guid studentId, bool trackChanges);

    void CreateStudent(Student student);

    void UpdateStudent(Student student);

    void DeleteStudent(Student student);
    Task<IEnumerable<Student>> GetStudentsByIdsAsync(IEnumerable<Guid> studentIds, bool trackChanges);
}
