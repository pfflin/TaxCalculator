namespace Taxes.Core.Implementations
{
    using Taxes.Core.Interfaces;

    internal class SalaryCalculator : ISalaryCalculator
    {
        private int _grossSalary;
        public SalaryCalculator(int grossSalary)
        {
            _grossSalary = grossSalary;
        }
        public int GetCalculatedSalary()
        {
            return _grossSalary;
        }

        public int GetGrossSalary()
        {
            return _grossSalary;
        }
    }
}
