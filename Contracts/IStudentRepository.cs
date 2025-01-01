using System;
using Entities.Models;

namespace Contracts;

public interface IStudentRepository
{
    IEnumerable<Student> GetAllStudents(bool trackChanges);
}
