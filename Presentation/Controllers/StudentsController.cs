using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Presentation.ModelBinders;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{

    private readonly IServiceManager _service;

    public StudentsController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _service.Student.GetAllStudentsAsync(trackChanges: false);

        return Ok(students);
    }

    [HttpGet("{studentId:guid}", Name = "GetSingleStudent")]
    public async Task<IActionResult> GetSingleStudent(Guid studentId)
    {
        var studentDto = await _service.Student.GetStudentAsync(studentId, false);

        return Ok(studentDto);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateNewStudent([FromBody] StudentForCreationDto studentDto)
    {
        var newStudent = await _service.Student.CreateStudentAsync(studentDto);
        
        return CreatedAtRoute("GetSingleStudent", new {studentId = newStudent.Id}, newStudent);
    }

    [HttpPut("{studentId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateStudent(Guid studentId, [FromBody] StudentForUpdateDto studentForUpdateDto)
    {
        await _service.Student.UpdateStudentAsync(studentId, studentForUpdateDto, true);
        
        return NoContent();
    }
    
    [HttpPatch("{studentId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdatePartialStudent(Guid studentId,
        [FromBody] JsonPatchDocument<StudentForUpdateDto> studentPatch)
    {
        var result = await _service.Student.GetStudentForPatch(studentId, true);
        
        studentPatch.ApplyTo(result.studentPatch, ModelState);

        await _service.Student.SavePatchedStudent(result.studentPatch, result.studentEntity);

        return NoContent();

    }

    [HttpDelete("{studentId:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        await _service.Student.DeleteStudentAsync(studentId);

        return NoContent();
    }

    [HttpGet("{studentId:guid}/courses")]
    public async Task<IActionResult> GetStudentCourses(Guid studentId)
    {
        var studentCourses = await _service.Student.GetStudentCoursesAsync(studentId, false);

        return Ok(studentCourses);
    }

    [HttpGet("collection/({studentIds})", Name = "GetStudentByIds")]
    public async Task<IActionResult> GetStudentByIds([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> studentIds)
    {
        var students = await _service.Student.GetStudentByIdsAsync(studentIds, false);

        return Ok(students);
    }

    [HttpPost("collection")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateStudentCollection(
        [FromBody] IEnumerable<StudentForCreationDto> studentForCreationDtos)
    {
        var result = await _service.Student.CreateStudentCollection(studentForCreationDtos);

        return CreatedAtRoute("GetStudentByIds", new { studentIds = result.ids }, result.studentDtos);
    }

}
