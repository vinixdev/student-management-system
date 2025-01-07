using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;
[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
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
        var course = await _service.Course.GetCourseAsync(courseId, trackChanges: false);

        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CourseForCreationDto? courseForCreationDto)
    {
        if (courseForCreationDto == null) return BadRequest("courseForCreationDto is null.");

        var course = await _service.Course.CreateCourseAsync(courseForCreationDto);

        return CreatedAtRoute("GetSingleCourse", new { courseId = course.Id }, course);

    }

    [HttpDelete("{courseId:guid}")]
    public async Task<IActionResult> DeleteCourse(Guid courseId)
    {
        await _service.Course.DeleteCourseAsync(courseId);
        return NoContent();
    }

    [HttpPut("{courseId:guid}")]
    public async Task<IActionResult> UpdateCourse(Guid courseId, [FromBody] CourseForUpdateDto? courseForUpdateDto)
    {
        if (courseForUpdateDto == null) return BadRequest("courseForUpdateDto is null.");

        var updatedCourse = await _service.Course.UpdateCourseAsync(courseId, courseForUpdateDto, trackChanges: true);

        return Ok(updatedCourse);

    }

    [HttpPatch("{courseId:guid}")]
    public async Task<IActionResult> PartialUpdateCourse(Guid courseId,
        [FromBody] JsonPatchDocument<CourseForUpdateDto>? courseForUpdateDto)
    {
        if (courseForUpdateDto == null) return BadRequest("courseForUpdateDto is null.");

        var result = await _service.Course.GetCourseForPatchAsync(courseId, trackChanges: true);

        courseForUpdateDto.ApplyTo(result.courseForUpdateDto, ModelState);

        await _service.Course.SavePatchedCourseAsync(result.courseForUpdateDto, result.courseEntity);

        return NoContent();
    }

    [HttpGet("{courseId:guid}/students")]
    public async Task<IActionResult> GetCourseStudents(Guid courseId)
    {
        var courseStudents = await _service.Course.GetCourseStudentsAsync(courseId, false);

        return Ok(courseStudents);
    }

    [HttpGet("collection/({courseIds})", Name = "GetCourseByIds")]
    public async Task<IActionResult> GetCourseByIds(IEnumerable<Guid> courseIds)
    {
        var courses = await _service.Course.GetCourseByIds(courseIds, false);

        return Ok(courses);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateCourseCollection([FromBody] IEnumerable<CourseForCreationDto>? courseCreationDtoCollection)
    {

        if (courseCreationDtoCollection == null) return BadRequest("Course collection is empty.");

        var result = await _service.Course.CreateCourseCollection(courseCreationDtoCollection);

        return CreatedAtRoute("GetCourseByIds", new { courseIds = result.ids }, result.courses);
    }


}
