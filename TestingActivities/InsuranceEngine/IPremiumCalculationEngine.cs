using Common.Contracts;

namespace InsuranceEngine;

public interface IPremiumCalculationEngine
{
    public double CalculatePremium(InsurancePremiumCalculationRequest request);
}