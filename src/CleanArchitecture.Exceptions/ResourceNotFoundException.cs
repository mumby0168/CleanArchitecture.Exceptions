namespace CleanArchitecture.Exceptions;

/// <summary>
/// An exception that is thrown when a resource is not found
/// </summary>
public class ResourceNotFoundException : BaseCleanArchitectureException
{
    /// <summary>
    /// Creates a resource not found exception with a given message and code.
    /// </summary>
    /// <param name="message">A message to describe the resource not found exception</param>
    /// <param name="code">A code to detail the exception  defaults to resource_not_found</param>
    public ResourceNotFoundException(string message, string? code = null) : base(message)
    {
        Code = code ?? ExceptionsCodes.ResourceNotFound;
    }
}

/// <inheritdoc cref="ResourceNotFoundException"/>
/// <typeparam name="T">The type of resource that already exists</typeparam>
public class ResourceNotFoundException<T> : ResourceNotFoundException
{
    /// <summary>
    /// Creates a resource not found exception with a given message and code.
    /// </summary>
    /// <param name="message">A message to describe the resource not found exception</param>
    /// <param name="code">A code to detail the exception defaults to resource_not_found</param>
    public ResourceNotFoundException(string message, string? code = null) : base(message, code)
    {
        Code = code ?? ExceptionsCodes.ResourceNotFound;
        Type = typeof(T);
    }
}