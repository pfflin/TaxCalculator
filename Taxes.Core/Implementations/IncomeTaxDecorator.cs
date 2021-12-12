namespace Taxes.Core.Implementations
{
    using Taxes.Core.Interfaces;

    internal class IncomeTaxDecorator : TaxesDecorator
    {
        public IncomeTaxDecorator(ISalaryCalculator salaryCalculator) : base(salaryCalculator)
        {}

        public override int GetCalculatedSalary()
        {
            var grossSalary = GetGrossSalary();
            var currentValue = base.GetCalculatedSalary();
            var excess = grossSalary - TaxConstants.NonTaxableMinimum;

            return excess > 0 
                ? IncomeTaxDeductor(currentValue, grossSalary)
                : currentValue;
        }

        private int IncomeTaxDeductor(int salary, int grossSalary)
        {
            var taxableAmount = (grossSalary - TaxConstants.NonTaxableMinimum) * TaxConstants.IncomeTaxMultiplier;

            return salary - (int)taxableAmount;
        }
    }
}
