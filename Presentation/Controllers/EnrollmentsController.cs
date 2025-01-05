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
    public async Task<IActionResult> StudentEnrollCourse(Guid studentId, Guid courseId)
    {
        var enrollmentForCreationDto = new EnrollmentForCreationDto();
        enrollmentForCreationDto.StudentId = studentId;
        enrollmentForCreationDto.CourseId = courseId;

        await _service.Enrollment.CreateEnrollment(enrollmentForCreationDto);

        return NoContent();
    }
}
