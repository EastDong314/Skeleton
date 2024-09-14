namespace Skeleton.Exception;

public class ResourceAlreadyExistException(string code = "5001", string? message = "Resource Already Exist")
    : DomainException(code, message);