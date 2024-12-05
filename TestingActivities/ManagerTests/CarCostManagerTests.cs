using System.Data;
using CarManager;
using Common.Contracts;
using ContractFakers;
using FluentAssertions;
using InsuranceEngine;
using Moq;

namespace ManagerTests;

[TestClass]
public class CarCostManagerTests
{
    private ICarCostManager _sut;
    private Mock<IPremiumCalculationEngine> _premiumCalculationEngineMock = new(MockBehavior.Strict);
    
    [TestInitialize]
    public void Setup()
    {
        _sut = new CarCostManager(_premiumCalculationEngineMock.Object);
    }

    #region GetMontlyCost
    
    [TestMethod]
    public void GetMonthlyCost_CarMadeAfter2019_ReturnsValidPrice()
    {
        // Arrange
        var car = new Car
        {
            Make = "Honda",
            Model = "Civic",
            Vin = "1234567890",
            MakeYear = 2020
        };
        
        _premiumCalculationEngineMock.Setup(x => x.CalculatePremium(It.IsAny<InsurancePremiumCalculationRequest>()))
            .Returns(100.0).Verifiable();
        
        // Act
        var monthlyCost = _sut.GetMontlyCost(car);
        
        // Assert
        monthlyCost.Should().Be(600.0);
        _premiumCalculationEngineMock.Verify(x => x.CalculatePremium(It.IsAny<InsurancePremiumCalculationRequest>()), Times.Once);
    }
    
    // Activity 1: Write the next basis test after the nominal case
    [TestMethod]
    public void GetMontlyCost__ReturnsValidCost()
    {
        throw new NotImplementedException();
    }
    
    
    [TestMethod]
    public void GetMontlyCost_CarMadeBefore1968_ThrowsDataException()
    {
        // Arrange
        var car = new CarFaker().RuleFor(c => c.MakeYear, _ => 1967).Generate();
        
        // Act & Assert
        Action act = () => _sut.GetMontlyCost(car);
        act.Should().Throw<DataException>()
            .WithMessage("Invalid make year, cars prior to 1968 are not supported.");
    }
    
    #endregion
    
    #region GetAllHondas
    
    [TestMethod]
    public void GetAllHondas_ReturnsTwo()
    {
        // Arrange
        var cars = new List<Car>
        {
            new Car
            {
                Make = "Honda",
                Model = "Civic",
                Vin = "1234567890",
                MakeYear = 2020
            },
            new Car
            {
                Make = "Toyota",
                Model = "Corolla",
                Vin = "0987654321",
                MakeYear = 2019
            },
            new Car
            {
                Make = "Honda",
                Model = "Civic",
                Vin = "1234567891",
                MakeYear = 2002
            }
        };
        
        // Act
        var uniqueCars = CarCostManager.GetAllHondas(cars);
        
        // Assert
        uniqueCars.Should().HaveCount(2);
    }
    
    [TestMethod]
    public void GetAllHondas_ReturnsCalculatedAmount()
    {
        // Arrange
        var cars = new CarFaker().Generate(50);
        var expectedCount = cars.Count(x => x.Make == "Honda");
        
        // Act
        var uniqueCars = CarCostManager.GetAllHondas(cars);
        
        // Assert
        uniqueCars.Should().HaveCount(expectedCount);
    }
    
    #endregion
}