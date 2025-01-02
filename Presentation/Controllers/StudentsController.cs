using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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

    [HttpPost]
    public async Task<IActionResult> CreateNewStudent([FromBody] StudentForCreationDto? studentDto)
    {
        if (studentDto == null) return BadRequest("StudentDto object is null.");
        
        await _service.Student.CreateStudent(studentDto);
        return Ok("Student Created Successfully.");
    }

}
