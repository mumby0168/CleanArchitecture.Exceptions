namespace CleanArchitecture.Exceptions;

/// <summary>
/// A collection of default exception codes
/// </summary>
public static class ExceptionsCodes
{
    /// <summary>
    /// The default exception code for the <see cref="ResourceNotFoundException"/>
    /// </summary>
    public const string ResourceNotFound = "resource_not_found";

    /// <summary>
    /// The default exception code for the <see cref="ResourceExistsException"/>
    /// </summary>
    public const string ResourceExists = "resource_exists";

    /// <summary>
    /// The default exception code for the <see cref="DomainException"/>
    /// </summary>
    public const string Domain = "domain_rule_violation";
}