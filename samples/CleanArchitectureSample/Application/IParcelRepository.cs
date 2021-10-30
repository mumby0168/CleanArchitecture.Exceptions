using CleanArchitectureSample.Domain;

namespace CleanArchitectureSample.Application;

/// <summary>
/// This is not implemented is just here to show the application layer
/// </summary>
public interface IParcelRepository
{
    ValueTask<Parcel?> GetParcel(string barcode);

    ValueTask<bool> ParcelExists(string barcode);

    ValueTask<ParcelItem?> GetParcelItem(string parcelItemId);

    ValueTask CreateParcel(Parcel parcel);
}