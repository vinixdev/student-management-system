using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public sealed class StudentRepository : RepositoryBase<Student>, IStudentRepository
{

    public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<Student> GetStudentAsync(Guid studentId, bool trackChanges)
    {
        return await FindByCondition(s => s.Id.Equals(studentId), trackChanges).SingleOrDefaultAsync();
    }

    public void CreateStudent(Student student) => Create(student);
}
