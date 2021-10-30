using CleanArchitecture.Exceptions;

namespace CleanArchitectureSample.Domain;

public class ParcelItem
{
    public string Id { get; }
    
    public string ProductId { get; }

    public ParcelItem(string id, string productId)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new DomainException<ParcelItem>("A parcel item must have an id");
        }
        
        if (string.IsNullOrWhiteSpace(productId))
        {
            throw new DomainException<ParcelItem>("A parcel item must have a product id");
        }
        
        Id = id;
        ProductId = productId;
    }
}