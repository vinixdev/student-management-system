using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class EnrollmentService : ServiceBase, IEnrollmentService
{
    public EnrollmentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper): base(logger, repositoryManager, mapper)
    {
    }

    public async Task CreateEnrollment(EnrollmentForCreationDto enrollmentForCreationDto)
    {
        var enrollmentEntity = Mapper.Map<Enrollment>(enrollmentForCreationDto);
        
        Repository.Entrollment.CreateEnrollment(enrollmentEntity);

        await Repository.SaveAsync();
    }
}
