namespace CleanArchitecture.Exceptions;

public class ResourceNotFoundException : BaseCleanArchitectureException
{
    public ResourceNotFoundException(string message, string? code = null) : base(message)
    {
        Code = code ?? ExceptionsCodes.ResourceNotFound;
    }
}

public class ResourceNotFoundException<T> : ResourceNotFoundException
{
    public ResourceNotFoundException(string message, string? code = null) : base(message, code)
    {
        Code = code ?? ExceptionsCodes.ResourceNotFound;
        Type = typeof(T);
    }
}