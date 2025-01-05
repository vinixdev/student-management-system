using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
}
