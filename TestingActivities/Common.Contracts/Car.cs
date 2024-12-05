using Common.Contracts.Enums;

namespace Common.Contracts;

public class Car
{
    public required string Make { get; set; }
    public required string Model { get; set; }
    public required int MakeYear { get; set; }
    public string? Vin { get; set; }
    public  Transmission TransmissionType { get; set; }
}