using System;

namespace Entities.Exceptions;

public class EntityCollectionEmpty : BadRequestException
{
    public EntityCollectionEmpty(string entityName) : base($"{entityName} collection is empty.") { }
}
