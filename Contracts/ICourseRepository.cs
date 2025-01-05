using System;
using Entities.Models;

namespace Contracts;

public interface ICoruseRepository
{
    Task<IEnumerable<Course>> GetAllCourses();
}
