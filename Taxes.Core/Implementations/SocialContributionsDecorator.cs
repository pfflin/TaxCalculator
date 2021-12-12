namespace Taxes.Core.Implementations
{
    using System;
    using Taxes.Core.Interfaces;

    internal class SocialContributionsDecorator : TaxesDecorator
    {
        public SocialContributionsDecorator(ISalaryCalculator salaryCalculator) : base(salaryCalculator)
        {}

        public override int GetCalculatedSalary()
        {
            var grossSalary = GetGrossSalary();
            var currentValue = base.GetCalculatedSalary();
            var excess = grossSalary - TaxConstants.NonTaxableMinimum;

            return excess > 0
                ? SocialContributionsDeductor(currentValue, grossSalary)
                : currentValue;
        }

        private int SocialContributionsDeductor(int salary, int grossSalary)
        {
            var taxableAmount = (Math.Min(grossSalary, TaxConstants.SocialContributionsMaximumAmount) - TaxConstants.NonTaxableMinimum) * TaxConstants.SocialContributionsMultiplier;

            return salary - (int)taxableAmount;
        }
    }
}
