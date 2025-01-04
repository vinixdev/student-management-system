using System;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> CreateNewStudent([FromBody] StudentForCreationDto? studentDto)
    {
        if (studentDto == null) return BadRequest("StudentDto object is null.");
        
        var newStudent = await _service.Student.CreateStudentAsync(studentDto);
        
        return CreatedAtRoute("GetSingleStudent", new {studentId = newStudent.Id}, newStudent);
    }

    [HttpPut("{studentId:guid}")]
    public async Task<IActionResult> UpdateStudent(Guid studentId, [FromBody] StudentForUpdateDto? studentForUpdateDto)
    {
        if (studentForUpdateDto == null) return BadRequest("StudentForUpdateDto is null.");
        
        await _service.Student.UpdateStudentAsync(studentId, studentForUpdateDto, true);
        
        return NoContent();
    }

    [HttpDelete("{studentId:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        await _service.Student.DeleteStudentAsync(studentId);

        return NoContent();
    }

}
