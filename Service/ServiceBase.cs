using AutoMapper;
using Contracts;
using Entities.Models;

namespace Service;

public class ServiceBase
{

    protected readonly ILoggerManager Logger;
    protected readonly IRepositoryManager Repository;
    protected readonly IMapper Mapper;

    public ServiceBase(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    protected async Task<(bool success, TEntity? entity)> TryGetEntityAsync<TEntity>(Guid entityId, bool trackChanges) where TEntity: class
    {
        var entity =  typeof(TEntity) switch
        {
            
            { } t when t == typeof(Student) => await Repository.Student.GetStudentAsync(entityId, trackChanges),
            _ => null
        };

        return (entity != null, entity as TEntity);
    }
    
}