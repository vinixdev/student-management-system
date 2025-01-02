using System;
using Entities.Models;

namespace Contracts;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);

    void CreateStudent(Student student);
}
