namespace Entities.Exceptions;

public sealed class EntityNotFound : NotFoundException
{
    public EntityNotFound(string entityName, Guid id) : base($"{entityName} with Id '{id}' not found.")
    { }

    public EntityNotFound(string message) : base(message) { }
}