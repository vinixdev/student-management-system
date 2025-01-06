namespace Entities.Exceptions;

public class EnrollmentNotFound: NotFoundException
{
    public EnrollmentNotFound(): base("Enrollment not found."){}
}