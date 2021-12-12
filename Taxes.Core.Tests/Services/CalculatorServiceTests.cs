namespace Taxes.Core.Tests.Services
{
    using Taxes.Core.Services;
    using Xunit;

    public class CalculatorServiceTests
    {
        [Fact]
        public void CalculateShouldReturnLessThanOriginalValue()
        {
            var salary = 2500;
            var calculatorService = new CalculatorService();

            var result = calculatorService.Calculate(salary);

            Assert.True(result < salary);
        }
    }
}
