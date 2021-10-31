namespace CleanArchitecture.Exceptions;


/// <summary>
/// A base exception for all clean architecture exceptions
/// </summary>
public abstract class BaseCleanArchitectureException : Exception
{
    /// <summary>
    /// A code detailing the exception words all split with underscores i.e. parcel_not_found
    /// </summary>
    /// <remarks>If not specified defaults to undefined</remarks>
    public string Code { get; protected set; }
    
    /// <summary>
    /// The type of resource the exception affected
    /// </summary>
    /// <remarks>Only available if specified</remarks>
    public Type? Type { get; protected set; }

    /// <summary>
    /// Creates a exception with a message
    /// </summary>
    /// <param name="message">The message that details the exception.</param>
    protected BaseCleanArchitectureException(string message) : base(message) => 
        Code = "undefined";
}