namespace Entities.Exceptions;

public class EnrollmentNotFound: NotFoundException
{
    public EnrollmentNotFound(): base("Enrollment not found."){}
}

// TODO: Refactor to EntityNotFound with another overload