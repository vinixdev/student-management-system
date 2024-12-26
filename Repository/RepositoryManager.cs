using System;
using Contracts;
using Entities.Models;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IStudentRepository> _studentRepository;
    private readonly Lazy<ICoruseRepository> _courseRepository;
    private readonly Lazy<IEnrollmentRepository> _enrollmentRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _courseRepository = new Lazy<ICoruseRepository>(() => new CoruseRipository(_repositoryContext));
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(_repositoryContext));
        _enrollmentRepository = new Lazy<IEnrollmentRepository>(() => new EnrollmentRepository(_repositoryContext));
    }

    public IStudentRepository Student => _studentRepository.Value;
    public ICoruseRepository Course => _courseRepository.Value;
    public IEnrollmentRepository Entrollment => _enrollmentRepository.Value;
    public void Save() => _repositoryContext.SaveChanges();
}
