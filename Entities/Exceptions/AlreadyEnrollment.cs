namespace Entities.Exceptions;

public class AlreadyEnrollment: BadRequestException
{
    public AlreadyEnrollment(Guid studentId, Guid courseId):base($"Student with Id '{studentId}' already enrolled in course with Id '{courseId}'") {}
}