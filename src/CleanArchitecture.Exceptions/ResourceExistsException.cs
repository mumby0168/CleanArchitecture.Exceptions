namespace CleanArchitecture.Exceptions;

/// <summary>
/// An exception that is thrown when a resource already exists
/// </summary>
public class ResourceExistsException : BaseCleanArchitectureException
{
    /// <summary>
    /// Creates a resource exists exception with a given message and code.
    /// </summary>
    /// <param name="message">A message to describe the resource exists exception</param>
    /// <param name="code">A code to detail the exception  defaults to resource_exists</param>
    public ResourceExistsException(string message, string? code = null) : base(message)
    {
        Code = code ?? ExceptionsCodes.ResourceExists;
    }
}

/// <inheritdoc cref="ResourceExistsException"/>
/// <typeparam name="T">The type of resource that already exists</typeparam>
public class ResourceExistsException<T> : ResourceNotFoundException
{
    /// <summary>
    /// Creates a resource exists exception with a given message and code.
    /// </summary>
    /// <param name="message">A message to describe the resource exists exception</param>
    /// <param name="code">A code to detail the exception defaults to resource_exists</param>
    public ResourceExistsException(string message, string? code = null) : base(message, code)
    {
        Code = code ?? ExceptionsCodes.ResourceExists;
        Type = typeof(T);
    }
}