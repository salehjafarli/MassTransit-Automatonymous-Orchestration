using Api2Core.Consumers.Category;
using Api2Core.Consumers.Product;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Core.Extensions
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
                x.AddConsumer<CategoryConsumer>();

                x.AddConsumer<ProductCreatedConsumer>();
                x.AddConsumer<ProductUpdatedConsumer>();
                x.AddConsumer<ProductDeletedConsumer>();
                

            });

            Services.AddMassTransitHostedService();
        }
    }
}
