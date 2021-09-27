using System;
using AppServices;
using AppServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TimeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IClockService, ClockService>()
                .AddSingleton<IValidationService, ValidationService>()
                .BuildServiceProvider();

            var clockService = serviceProvider.GetService<IClockService>();
            var validationService = serviceProvider.GetService<IValidationService>(); 

            var message = string.Empty;
            var userInput = args.Length == 0 ? string.Empty : args[0];

            //Check for valid input
            if (validationService.IsTimeValid(userInput, out message))
            {
                Console.WriteLine(clockService.getTimeText(args[0]));
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
