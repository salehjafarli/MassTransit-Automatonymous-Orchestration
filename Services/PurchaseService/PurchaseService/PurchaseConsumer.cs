using MassTransit;
using Services.Common.Events.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseService
{
    public class PurchaseConsumer : IConsumer<PurchaseOrder>
    {
        public PurchaseConsumer()
        {

        }
        public PurchaseConsumer(IBusControl Bus)
        {
            this.Bus = Bus;
        }

        public IBusControl Bus { get; }

        public async Task Consume(ConsumeContext<PurchaseOrder> context)
        {
            //Check card details and etc
            await Bus.Publish(new OrderPurchased());

            
        }
    }
}
