using CarManager;
using Common.Contracts.Enums;
using ContractFakers;
using FluentAssertions;
using InsuranceEngine;

namespace IntegrationTests;

[TestClass]
public class CarCostIntegrationTests
{
    private ICarCostManager _sut;
    
    [TestInitialize]
    public void Setup()
    {
        IPremiumCalculationEngine engine = new PremiumCalculationEngine();
        _sut = new CarCostManager(engine);
    }
    
    // Activity 1: Determine Why this test is failing
    [TestMethod]
    public void GetMonthlyCost_Automatic_MadeIn2020_ReturnsValidPrice()
    {
        // Arrange
        var car = new CarFaker()
                .RuleFor(c => c.MakeYear, _ => 2020)
                .RuleFor(c => c.TransmissionType , _ => Transmission.Automatic)
                .Generate()
            ;
        
        // Act
        var monthlyCost = _sut.GetMontlyCost(car);
        
        // Assert
        monthlyCost.Should().Be(700.0);
    }
    
    // Activity 2: Write the next basis test
    [TestMethod]
    public void GetMonthlyCost_InsertValidNameHere_ReturnsValidPrice()
    {
        throw new NotImplementedException();
    }
}