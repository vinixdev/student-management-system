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
}
