namespace CleanArchitecture.Exceptions;

public class ResourceExistsException : BaseCleanArchitectureException
{
    public ResourceExistsException(string message, string? code = null) : base(message)
    {
        Code = code ?? ExceptionsCodes.ResourceExists;
    }
}

public class ResourceExistsException<T> : ResourceNotFoundException
{
    public ResourceExistsException(string message, string? code = null) : base(message, code)
    {
        Code = code ?? ExceptionsCodes.ResourceExists;
        Type = typeof(T);
    }
}