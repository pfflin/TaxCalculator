namespace Taxes.Core.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Taxes.Core.Implementations;
    using Taxes.Core.Interfaces;
    using Taxes.Core.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterTaxingServices(this IServiceCollection services)
        {
            services
                .AddTransient<ISalaryCalculator, SalaryCalculator>()
                .AddTransient<ICalculatorService, CalculatorService>();

            return services;
        }
    }
}
