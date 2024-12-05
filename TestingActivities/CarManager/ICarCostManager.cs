using Common.Contracts;

namespace CarManager;

public interface ICarCostManager
{
    public double GetMontlyCost(Car car);
}