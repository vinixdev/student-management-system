using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;

namespace Service;

public class StudentService : ServiceBase, IStudentService
{
    public StudentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper) : base(logger, repositoryManager, mapper) {}


    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges)
    {

        var students = await Repository.Student.GetAllStudentsAsync(trackChanges);

        var studentsDtos = Mapper.Map<IEnumerable<StudentDto>>(students);

        return studentsDtos;

    }

    public async Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentForCreationDto)
    {
        var studentEntity = Mapper.Map<Student>(studentForCreationDto);
        
        studentEntity.StdId = Guid.NewGuid().ToString("N");
        
        Repository.Student.CreateStudent(studentEntity);
        
        await Repository.SaveAsync();

        var studentDto = Mapper.Map<StudentDto>(studentEntity);

        return studentDto;
    }

    public async Task<StudentDto> GetStudentAsync(Guid studentId, bool trackChanges)
    {
        var studentEntity = await TryGetEntityAsync<Student>(studentId, trackChanges);

        var studentDto = Mapper.Map<StudentDto>(studentEntity);

        return studentDto;

    }

    public async Task UpdateStudentAsync(Guid studentId, StudentForUpdateDto studentForUpdate, bool trackChanges)
    {
        var studentEntity = await TryGetEntityAsync<Student>(studentId, trackChanges);

        Mapper.Map(studentForUpdate, studentEntity);
        
        await Repository.SaveAsync();
    }

    public async Task UpdatePartialStudentAsync(Guid studentId, bool trackChanges)
    {
        
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        var studentEntity = await TryGetEntityAsync<Student>(studentId, false);
        
        Repository.Student.DeleteStudent(studentEntity);

        await Repository.SaveAsync();
    }
}
