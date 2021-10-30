using CleanArchitecture.Exceptions;

namespace CleanArchitectureSample.Domain;

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