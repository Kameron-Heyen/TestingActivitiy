using Common.Contracts;
using Common.Contracts.Enums;

namespace InsuranceEngine;

public class PremiumCalculationEngine: IPremiumCalculationEngine
{
    /**
     * Calculate the premium for a car based on the car's make year and transmission type.
     *
     * The premium is calculated as follows:
     * - The base premium is $100.00.
     * - If the car's make year is greater than 2012, add $50.00 to the premium.
     * - If the car's transmission type is automatic, add $50.00 to the premium.
     * - If the car's transmission type is manual, add $25.00 to the premium.
     * 
     * @param Request information used to calculate the premium.
     * @return The premium amount.
     */
    
    public double CalculatePremium(InsurancePremiumCalculationRequest request)
    {
        var premium = 100.00;
        
        if (request.MakeYear > 2012)
        {
            premium += 50.00;
        }

        switch (request.TransmissionType)
        {
            case Transmission.Automatic:
                premium += 50.00;
                break;
            case Transmission.Manual:
                premium += 25.00;
                break;
        }
        
        return premium;
    }
}