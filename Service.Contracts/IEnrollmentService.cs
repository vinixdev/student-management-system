using System;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IEnrollmentService
{
    Task CreateEnrollment(EnrollmentForCreationDto enrollmentForCreationDto);
}
