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

    public async Task CreateEnrollment(Guid studentId, Guid courseId, EnrollmentForCreationDto? enrollmentForCreationDto)
    {
        var enrollmentEntity = Mapper.Map<Enrollment>(enrollmentForCreationDto);

        enrollmentEntity.StudentId = studentId;
        enrollmentEntity.CourseId = courseId;
        
        Repository.Entrollment.CreateEnrollment(enrollmentEntity);

        await Repository.SaveAsync();
    }
    public async Task DeleteEnrollmentAsync(Guid studentId, Guid courseId, bool trackChanges)
    {
        var enrollmentEntity = await Repository.Entrollment.GetEnrollmentAsync(studentId, courseId, trackChanges);

        if (enrollmentEntity == null) throw new Exception("Enrollment does not exits.");
        
        Repository.Entrollment.DeleteEnrollment(enrollmentEntity);

        await Repository.SaveAsync();
    }
}
