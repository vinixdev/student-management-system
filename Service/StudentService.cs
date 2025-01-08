using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

    public async Task<(StudentForUpdateDto studentPatch, Student studentEntity)> GetStudentForPatch(Guid studentId, bool trackChanges)
    {
        var studentEntity = await TryGetEntityAsync<Student>(studentId, trackChanges);

        var studentPatch = Mapper.Map<StudentForUpdateDto>(studentEntity);
        
        return (studentPatch, studentEntity);
    }

    public async Task SavePatchedStudent(StudentForUpdateDto studentPatch, Student studentEntity)
    {
        Mapper.Map(studentPatch, studentEntity);
        await Repository.SaveAsync();
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        var studentEntity = await TryGetEntityAsync<Student>(studentId, false);
        
        Repository.Student.DeleteStudent(studentEntity);

        await Repository.SaveAsync();
    }
    public async Task<IEnumerable<CourseDto>> GetStudentCoursesAsync(Guid studentId, bool trackChanges)
    {
        await TryGetEntityAsync<Student>(studentId, trackChanges);

        var studentEnrollments = await Repository.Entrollment.GetEnrollmentsByStudentIdAsync(studentId, trackChanges);

        var courseIds = studentEnrollments.Select(e => e.CourseId).ToList();

        if (courseIds.Count == 0) return [];

        var courses = await Repository.Course.GetCoursesByIdsAsync(courseIds, trackChanges);

        var coursesToReturn = Mapper.Map<IEnumerable<CourseDto>>(courses);

        return coursesToReturn;
    }

    public async Task<IEnumerable<StudentDto>> GetStudentByIdsAsync(IEnumerable<Guid> studentIds, bool trackChanges)
    {
        if (studentIds is null || !studentIds.Any()) throw new IdsCollectionEmpty();

        var studentEntities = await Repository.Student.GetStudentsByIdsAsync(studentIds, trackChanges);

        var studentDtos = Mapper.Map<IEnumerable<StudentDto>>(studentEntities);

        return studentDtos;
    }

    public async Task<(IEnumerable<StudentDto> studentDtos, string ids)> CreateStudentCollection(IEnumerable<StudentForCreationDto> studentCreationDtos)
    {
        if (studentCreationDtos is null || !studentCreationDtos.Any()) throw new EntityCollectionEmpty(nameof(Student));

        var studentEntities = Mapper.Map<IEnumerable<Student>>(studentCreationDtos);

        foreach (var student in studentEntities)
        {
            Repository.Student.CreateStudent(student);
        }

        await Repository.SaveAsync();

        var studentDtos = Mapper.Map<IEnumerable<StudentDto>>(studentEntities);
        var ids = string.Join(',', studentDtos.Select(s => s.Id));

        return (studentDtos, ids);
    }
}
