namespace CleanArchitecture.Exceptions;

public class DomainException : BaseCleanArchitectureException
{
    public DomainException(string message, string? code = null) : base(message)
    {
        Code = code ?? ExceptionsCodes.Domain;
    }
}

public class DomainException<T> : ResourceNotFoundException
{
    public DomainException(string message, string? code = null) : base(message, code)
    {
        Code = code ?? ExceptionsCodes.Domain;
        Type = typeof(T);
    }
}