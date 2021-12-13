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
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                return;
            }

            using var host = CreateHostBuilder(args).Build();
            foreach(var command in args)
            {
                int salary;
                if(!int.TryParse(command, out salary))
                {
                    Console.WriteLine($"Invalid arg {command}");
                    continue;
                }

                Console.WriteLine(Calculate(host.Services, salary));
            }
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
