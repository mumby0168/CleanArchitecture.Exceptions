# CleanArchitecture.Exceptions
A set of exceptions to be used in projects looking to follow clean architecture

## Domain Layer Exceptions

In the domain layer object integrity is key, any domain rules of an object that are broken result in a `DomainException`. This forces the integrity of the entity make sure it's state is never not as expected. See below for the `Parcel` & `ParcelItem` entities that make use of this rule.

### Parcel

```csharp
public class Parcel
{
    private readonly List<ParcelItem> _items;
    
    public string Id { get; }

    public string Barcode { get; }

    public IReadOnlyList<ParcelItem> Items => _items;

    public Parcel(string barcode, List<ParcelItem> items)
    {
        if (string.IsNullOrWhiteSpace(barcode))
        {
            throw new DomainException<Parcel>("A parcel must have a barcode");
        }

        if (barcode.Length < 9)
        {
            throw new DomainException<Parcel>("A parcel's barcode must be at least 9 characters");
        }

        if (items.Count < 1)
        {
            throw new DomainException<Parcel>("A parcel must have at least one item");
        }
        
        Id = barcode;
        Barcode = barcode;
        _items = items;
    }
}
```


### Parcel Item

```csharp
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
```

## Application Layer Exceptions

Often when in the applicaiton layer of a project calls to some persitant data store is made and sometimes we don't have the record been requested or a record being created may conflict with one we aready have see the use of some of the common exceptions from this library below in the `ParcelsService`.

```csharp
public class ParcelsService : IParcelsService
{
    private readonly IParcelRepository _parcelRepository;

    public ParcelsService(IParcelRepository parcelRepository)
    {
        _parcelRepository = parcelRepository;
    }
    
    public async ValueTask CreateParcel(CreateParcel newParcel)
    {
        if (await _parcelRepository.ParcelExists(newParcel.Barcode))
        {
            throw new ResourceExistsException<Parcel>($"A parcel with the barcode {newParcel.Barcode} already exists");
        }

        var parcelItems = newParcel.Items.Select(x => new ParcelItem(x.Id, x.ProductId)).ToList();
        var parcel = new Parcel(newParcel.Barcode, parcelItems);

        await _parcelRepository.CreateParcel(parcel);
    }

    public async ValueTask<ParcelDto> GetParcel(string barcode)
    {
        Parcel? parcel = await _parcelRepository.GetParcel(barcode);

        if (parcel is null)
        {
            throw new ResourceNotFoundException<Parcel>($"A parcel with the barcode {barcode} does not exist");
        }

        return new ParcelDto()
        {
            Barcode = parcel.Barcode,
            Items = parcel.Items.Select(x => new ParcelItemDto(x.Id, x.ProductId))
        };
    }

    public async ValueTask<ParcelItem> GetParcelItem(string parcelItemId)
    {
        ParcelItem? parcelItem = await _parcelRepository.GetParcelItem(parcelItemId);

        if (parcelItem is null)
        {
            throw new ResourceNotFoundException<Parcel>($"A parcel item with the id {parcelItemId} does not exist");
        }

        return new ParcelItem(parcelItem.Id, parcelItem.ProductId);
    }
}
```
