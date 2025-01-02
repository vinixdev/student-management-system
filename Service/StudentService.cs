using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class StudentService : IStudentService
{

    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    private readonly IMapper _mapper;

    public StudentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repository = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges)
    {

        var students = await _repository.Student.GetAllStudentsAsync(trackChanges);

        var studentsDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

        return studentsDtos;

    }

    public async Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentForCreationDto)
    {
        var studentEntity = _mapper.Map<Student>(studentForCreationDto);
        
        studentEntity.StdId = Guid.NewGuid().ToString("N");
        
        _repository.Student.CreateStudent(studentEntity);
        
        await _repository.SaveAsync();

        var studentDto = _mapper.Map<StudentDto>(studentEntity);

        return studentDto;
    }

    public async Task<StudentDto> GetStudentAsync(Guid studentId, bool trackChanges)
    {
        var studentEntity = await _repository.Student.GetStudentAsync(studentId, trackChanges);

        if (studentEntity == null) throw new Exception($"Student with Id {studentId} not found.");

        var studentDto = _mapper.Map<StudentDto>(studentEntity);

        return studentDto;

    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        // TODO: refactor to method "Task<bool> TryGetStudent(Guid studentId, out Student? student)"
        
        var studentEntity = await _repository.Student.GetStudentAsync(studentId, false);

        if (studentEntity == null) throw new Exception($"Student with Id {studentId} not found.");
        
        _repository.Student.DeleteStudent(studentEntity);
        
        await _repository.SaveAsync();
    }
}
