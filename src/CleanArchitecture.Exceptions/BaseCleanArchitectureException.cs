namespace CleanArchitecture.Exceptions;

public abstract class BaseCleanArchitectureException : Exception
{
    public string Code { get; protected set; }
    
    public Type? Type { get; protected set; }

    protected BaseCleanArchitectureException(string message) : base(message) => 
        Code = "undefined";
}