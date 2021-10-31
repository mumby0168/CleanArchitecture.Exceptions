namespace CleanArchitecture.Exceptions;


/// <summary>
/// An exception that is thrown when a domain rule is violated.
/// </summary>
public class DomainException : BaseCleanArchitectureException
{
    /// <summary>
    /// Creates a domain exception with a given message and code.
    /// </summary>
    /// <param name="message">A message to describe the domain exception</param>
    /// <param name="code">A code to detail the exception  defaults to domain_rule_violation</param>
    public DomainException(string message, string? code = null) : base(message)
    {
        Code = code ?? ExceptionsCodes.Domain;
    }
}

///<inheritdoc cref="DomainException"/>
/// <typeparam name="T">The type of domain object that the rule was violated for.</typeparam>
public class DomainException<T> : ResourceNotFoundException
{
    /// <summary>
    /// Creates a domain exception with a given message and code.
    /// </summary>
    /// <param name="message">A message to describe the domain exception</param>
    /// <param name="code">A code to detail the exception  defaults to domain_rule_violation</param>
    public DomainException(string message, string? code = null) : base(message, code)
    {
        Code = code ?? ExceptionsCodes.Domain;
        Type = typeof(T);
    }
}