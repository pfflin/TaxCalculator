namespace Taxes.Core.Services
{
    using Taxes.Core.Implementations;
    using Taxes.Core.Interfaces;

    internal class CalculatorService : ICalculatorService
    {
        public int Calculate(int salary)
        {
            var salaryCalculator = new SalaryCalculator(salary);
            var incomeTaxDecorator = new IncomeTaxDecorator(salaryCalculator);
            var socialContributionsDecorator = new SocialContributionsDecorator(incomeTaxDecorator);

            return socialContributionsDecorator.GetCalculatedSalary();
        }
    }
}
