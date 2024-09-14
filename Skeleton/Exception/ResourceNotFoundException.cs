namespace Skeleton.Exception;

public class ResourceNotFoundException(string code = "4001", string? message = "Resource Not Found")
    : DomainException(code, message);