using Api2Business.Consumers.Category;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Extensions
{
    public static class MassTransitExtension
    {
        public static void InjectMassTransit(this IServiceCollection Services)
        {
            Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
                x.AddConsumer<CategoryCreatedConsumer>();
            });

            Services.AddMassTransitHostedService();
        }
    }
}
