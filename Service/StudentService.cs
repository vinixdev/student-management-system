using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
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
        var result = await TryGetEntityAsync<Student>(studentId, trackChanges);

        if (!result.success) throw new Exception($"Student with Id {studentId} not found.");

        var studentDto = Mapper.Map<StudentDto>(result.entity);

        return studentDto;

    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        var result = await TryGetEntityAsync<Student>(studentId, false);
        
        if (!result.success) throw new Exception($"Student with Id {studentId} not found.");
        
        Repository.Student.DeleteStudent(result.entity);

        await Repository.SaveAsync();
    }
}
