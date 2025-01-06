using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;
[ApiController]
[Route("api/students/{studentId:guid}/courses/{courseId:guid}")]
public class EnrollmentsController: ControllerBase
{
    private readonly IServiceManager _service;
    public EnrollmentsController(IServiceManager service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> StudentEnrollCourse(Guid studentId, Guid courseId, [FromBody] EnrollmentForCreationDto? enrollmentForCreationDto)
    {
        await _service.Enrollment.CreateEnrollment(studentId, courseId, enrollmentForCreationDto);

        return Created();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEnrollment(Guid studentId, Guid courseId)
    {
        await _service.Enrollment.DeleteEnrollmentAsync(studentId, courseId, false);

        return NoContent();
    }
}
