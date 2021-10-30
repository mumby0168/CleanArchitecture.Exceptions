using CleanArchitectureSample.Contracts;
using CleanArchitectureSample.Domain;

namespace CleanArchitectureSample.Application;

public interface IParcelsService
{
    ValueTask CreateParcel(CreateParcel newParcel);

    ValueTask<ParcelDto> GetParcel(string barcode);

    ValueTask<ParcelItem> GetParcelItem(string parcelItemId);
}