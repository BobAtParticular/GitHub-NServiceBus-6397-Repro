﻿using System;
using System.Threading.Tasks;
using NServiceBus;

namespace Billing
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "Billing";

            var endpointConfiguration = new EndpointConfiguration("Billing");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            var persistence = endpointConfiguration.UsePersistence<MongoPersistence>();
            persistence.DatabaseName("Tutorial_Billing");

            endpointConfiguration.RegisterComponents(
                c =>
                {
                    c.ConfigureComponent<OrderCalculator>(DependencyLifecycle.SingleInstance);
                }
                );

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}