using CleanArchitecture.Exceptions;
using CleanArchitectureSample.Contracts;
using CleanArchitectureSample.Domain;

namespace CleanArchitectureSample.Application;

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