using CleanArchitectureSample.Domain;

namespace CleanArchitectureSample.Contracts;

public record CreateParcel(string Barcode, List<ParcelItem> Items);