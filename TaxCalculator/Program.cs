namespace TaxCalculator
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using Taxes.Core.Extensions;
    using Taxes.Core.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            Console.WriteLine(Calculate(host.Services, 1001));
        }

        public static int Calculate(IServiceProvider services, int salaryValue)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;
            var calculatorService = provider.GetRequiredService<ICalculatorService>();

            return calculatorService.Calculate(salaryValue);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.RegisterTaxingServices());
        }
    }
}
