namespace Entities.Exceptions;

public class IdsCollectionEmpty: BadRequestException
{
    public IdsCollectionEmpty(): base("Ids Collection is empty."){}
}