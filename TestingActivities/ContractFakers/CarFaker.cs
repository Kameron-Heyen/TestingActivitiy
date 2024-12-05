using Bogus;
using Common.Contracts;
using Common.Contracts.Enums;

namespace ContractFakers;

public class CarFaker: Faker<Car>
{
    public CarFaker()
    {
        RuleFor(c => c.Make, f => f.Vehicle.Manufacturer());
        RuleFor(c => c.Model, f => f.Vehicle.Model());
        RuleFor(c => c.MakeYear, f => f.Date.Past(40).Year);
        RuleFor(c => c.TransmissionType, f => f.PickRandom<Transmission>());
    }
}