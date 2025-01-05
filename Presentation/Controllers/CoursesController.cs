using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;
[ApiController]
[Route("api/courses")]
public class CoursesController: ControllerBase
{
    private readonly IServiceManager _service;

    public CoursesController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _service.Course.GetAllCourses(trackChanges: false);

        return Ok(courses);
    }

    [HttpGet("{courseId:guid}", Name = "GetSingleCourse")]
    public async Task<IActionResult> GetSingleCourse(Guid courseId)
    {
        var course = await _service.Course.GetCourseAsync(courseId, trackChanges:false);

        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CourseForCreationDto? courseForCreationDto)
    {
        if (courseForCreationDto == null) return BadRequest("courseForCreationDto is null.");

        var course = await _service.Course.CreateCourseAsync(courseForCreationDto);

        return CreatedAtRoute("GetSingleCourse", new { courseId = course.Id }, course);

    }
}
