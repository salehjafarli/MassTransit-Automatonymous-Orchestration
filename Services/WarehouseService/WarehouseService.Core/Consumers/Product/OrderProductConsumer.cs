using Api2DataAccess.Repos.Abstract;
using MassTransit;
using Services.Common.Events.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseService.Core.Consumers.Product
{
    public class OrderProductConsumer : IConsumer<CheckProductAvailability>
    {
        public OrderProductConsumer(IWarehouseRepository Repo,IBusControl Bus)
        {
            this.Repo = Repo;
            this.Bus = Bus;
        }

        public IWarehouseRepository Repo { get; }
        public IBusControl Bus { get; }

        public async Task Consume(ConsumeContext<CheckProductAvailability> context)
        {
            var warehouses = await Repo.GetAll();
            var warehouse = warehouses.FirstOrDefault(w => w.Company.Id == context.Message.CompanyId);
            var product = warehouse.Products.FirstOrDefault(p => p.Id == context.Message.ProductId);
            if (product.Amount >0)
            {
                // update product amount in database
                await Bus.Publish(new OrderProductIsAvailable());
            }
            else
            {
                await Bus.Publish(new OrderRejected() { RejectReason = "Product is not available"});
            }

            
        }
    }
}
