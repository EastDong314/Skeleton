namespace Skeleton.Exception;

public class DomainException : System.Exception
{
    public string Code { get; set; }
    
    public DomainException(string code, string? message) : base(message)
    {
        Code = code;
    }

    public DomainException(string code, string? message, System.Exception? innerException) : base(message, innerException)
    {
        Code = code;
    }
}