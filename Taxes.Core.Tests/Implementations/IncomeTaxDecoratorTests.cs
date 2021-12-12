namespace Taxes.Core.Tests.Implementations
{
    using Moq;
    using Taxes.Core.Implementations;
    using Taxes.Core.Interfaces;
    using Xunit;

    public class IncomeTaxDecoratorTests
    {
        [Fact]
        public void CalculateSalaryGrossSalaryLessThanNonTaxableMinimumShouldReturnSameValue()
        {
            var salary = 999;
            var salaryCalculatorMock = new Mock<ISalaryCalculator>();
            salaryCalculatorMock
                .Setup(x => x.GetCalculatedSalary())
                .Returns(salary);
            salaryCalculatorMock
                .Setup(x => x.GetGrossSalary())
                .Returns(salary);
            var incomeTaxDecorator = new IncomeTaxDecorator(salaryCalculatorMock.Object);
            
            var result = incomeTaxDecorator.GetCalculatedSalary();

            Assert.Equal(salary, result);
        }

        [Fact]
        public void CalculateSalaryGrossSalaryOverNonTaxableMinimumShouldApplyDeductions()
        {
            var currentSalary = 999;
            var grossSalary = 2000;
            var salaryCalculatorMock = new Mock<ISalaryCalculator>();
            salaryCalculatorMock
                .Setup(x => x.GetCalculatedSalary())
                .Returns(currentSalary);
            salaryCalculatorMock
                .Setup(x => x.GetGrossSalary())
                .Returns(grossSalary);
            var incomeTaxDecorator = new IncomeTaxDecorator(salaryCalculatorMock.Object);

            var result = incomeTaxDecorator.GetCalculatedSalary();

            Assert.True(currentSalary > result);
        }

        [Fact]
        public void CalculateSalaryGrossSalaryAndCurrentSalaryOverNonTaxableMinimumShouldApplyDeductions()
        {
            var currentSalary = 2000;
            var grossSalary = 2000;
            var salaryCalculatorMock = new Mock<ISalaryCalculator>();
            salaryCalculatorMock
                .Setup(x => x.GetCalculatedSalary())
                .Returns(currentSalary);
            salaryCalculatorMock
                .Setup(x => x.GetGrossSalary())
                .Returns(grossSalary);
            var incomeTaxDecorator = new IncomeTaxDecorator(salaryCalculatorMock.Object);

            var result = incomeTaxDecorator.GetCalculatedSalary();

            Assert.True(currentSalary > result);
        }

        [Fact]
        public void CalculateSalaryShouldDeductNotMoreThanSocialContributionsTaxValue()
        {
            var currentSalary = 2500;
            var grossSalary = 2500;
            var socialContributionTaxValue = (currentSalary - TaxConstants.NonTaxableMinimum) * TaxConstants.IncomeTaxMultiplier;
            var salaryCalculatorMock = new Mock<ISalaryCalculator>();
            salaryCalculatorMock
                .Setup(x => x.GetCalculatedSalary())
                .Returns(currentSalary);
            salaryCalculatorMock
                .Setup(x => x.GetGrossSalary())
                .Returns(grossSalary);
            var incomeTaxDecorator = new IncomeTaxDecorator(salaryCalculatorMock.Object);

            var result = incomeTaxDecorator.GetCalculatedSalary();

            Assert.Equal(currentSalary - socialContributionTaxValue, result);
        }
    }
}
