using System;
using Entities.Models;

namespace Contracts;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudents(bool trackChanges);
}
