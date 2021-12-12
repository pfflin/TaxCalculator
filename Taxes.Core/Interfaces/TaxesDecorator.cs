namespace Taxes.Core.Interfaces
{
    internal abstract class TaxesDecorator : ISalaryCalculator
    {
        private ISalaryCalculator _salaryCalculator;

        public TaxesDecorator(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }

        public virtual int GetCalculatedSalary()
        {
            return _salaryCalculator.GetCalculatedSalary();
        }

        public int GetGrossSalary()
        {
            return _salaryCalculator.GetGrossSalary();
        }
    }
}
