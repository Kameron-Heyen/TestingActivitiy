using System.Data;
using Common.Contracts;
using InsuranceEngine;

namespace CarManager;

public class CarCostManager(IPremiumCalculationEngine premiumCalculationEngine) : ICarCostManager
{
    /*
     * This method calculates the monthly cost of a car based on the make year and the insurance premium.
     * If the make year is 2020 or later, the base monthly cost is $500.00.
     * If the make year is between 1968 and 2000, the base monthly cost is $200.00.
     * If the make year is before 1968, an exception is thrown.
     * The insurance premium is calculated using the provided IPremiumCalculationEngine.
     */
    public double GetMontlyCost(Car car)
    {
        var cost = 0.0;

        switch (car.MakeYear)
        {
            case >= 2020:
                cost += 500.0;
                break;
            case < 2000 and > 1968:
                cost += 200.0;
                break;
            case < 1968:
                throw new DataException("Invalid make year, cars prior to 1968 are not supported.");
        }
        
        cost += premiumCalculationEngine.CalculatePremium(new InsurancePremiumCalculationRequest()
        {
            MakeYear = car.MakeYear
        });
        
        return cost;
    }
    
    public static List<Car> GetAllHondas(List<Car> cars)
    {
        return cars.Where(x => x.Make == "Honda").ToList();
    }
}