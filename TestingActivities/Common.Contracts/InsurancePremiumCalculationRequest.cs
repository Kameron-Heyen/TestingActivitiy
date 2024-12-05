using Common.Contracts.Enums;

namespace Common.Contracts;

public class InsurancePremiumCalculationRequest
{
    public required int MakeYear { get; set; }
    public  Transmission TransmissionType { get; set; }
}