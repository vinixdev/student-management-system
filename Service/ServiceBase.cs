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

    protected async Task<TEntity> TryGetEntityAsync<TEntity>(Guid entityId, bool trackChanges) where TEntity: class
    {
        object? entity = null;
        
        if (typeof(TEntity) == typeof(Student)) 
            entity = await Repository.Student.GetStudentAsync(entityId, trackChanges);
        
        else if (typeof(TEntity) == typeof(Course))
            entity = await Repository.Course.GetCourseAsync(entityId, trackChanges);
        
        return entity as TEntity ?? throw new Exception($"{typeof(TEntity).Name} with Id {entityId} not found.");;
    }
    
    // TODO: Collection creation For Entities
    // TODO: Validation
    // TODO: Global error handling
    
}