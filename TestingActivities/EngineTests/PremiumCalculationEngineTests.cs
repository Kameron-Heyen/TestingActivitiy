using Common.Contracts;
using Common.Contracts.Enums;
using InsuranceEngine;

namespace EngineTests;

[TestClass]
public class PremiumCalculationEngineTests
{
    private IPremiumCalculationEngine _sut; // System Under Test
    
    [TestInitialize]
    public void TestInitialize()
    {
        _sut = new PremiumCalculationEngine();
    }
    
    [DataTestMethod]
    [DataRow(2013, Transmission.Automatic, 200.0)]
    [DataRow(2012, Transmission.Automatic, 150.0)]
    [DataRow(2013, Transmission.Manual, 175.0)]
    public void CalculatePremium_DataTest(int makeYear, Transmission transmissionType, double expectedPremium)
    {
        // Arrange
        var request = new InsurancePremiumCalculationRequest
        {
            MakeYear = makeYear,
            TransmissionType = transmissionType
        };

        // Act
        var calculatedPremium = _sut.CalculatePremium(request);

        // Assert
        Assert.AreEqual(expectedPremium, calculatedPremium);
    }
}