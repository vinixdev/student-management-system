using System;
using Contracts;
using Entities.Models;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IRepositoryStudent> _studentRepository;
    private readonly Lazy<IRepositoryCourse> _courseRepository;
    private readonly Lazy<IRepositoryEntrollment> _enrollmentRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _courseRepository = new Lazy<IRepositoryCourse>(() => new RepositoryCourse(_repositoryContext));
        _studentRepository = new Lazy<IRepositoryStudent>(() => new RepositoryStudent(_repositoryContext));
        _enrollmentRepository = new Lazy<IRepositoryEntrollment>(() => new RepositoryEnrollment(_repositoryContext));
    }

    public IRepositoryStudent Student => _studentRepository.Value;
    public IRepositoryCourse Course => _courseRepository.Value;
    public IRepositoryEntrollment Entrollment => _enrollmentRepository.Value;
    public void Save() => _repositoryContext.SaveChanges();
}
