using System;
using AppServices;
using AppServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CurrentTime
{
    class Program
    {
        static void Main()
        {
            //Setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IClockService, ClockService>()
                .BuildServiceProvider();

            var clockService = serviceProvider.GetService<IClockService>();

            //Get the current time
            Console.WriteLine(clockService.getCurrentTimeText());
        }

    }
}
