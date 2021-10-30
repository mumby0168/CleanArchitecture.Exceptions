namespace CleanArchitectureSample.Contracts;

public class ParcelDto
{
    public string Barcode { get; set; }

    public IEnumerable<ParcelItemDto> Items { get; set; }
}