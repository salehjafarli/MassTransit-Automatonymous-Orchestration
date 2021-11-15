using Api2DataAccess.Repos.Abstract;
using MassTransit;
using Services.Common.Events.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Consumers.Product
{
    class ProductDeletedConsumer : IConsumer<ProductDeleted>
    {
        public ProductDeletedConsumer(IProductRepository Repo)
        {
            this.Repo = Repo;
        }

        public IProductRepository Repo { get; }


        public async Task Consume(ConsumeContext<ProductDeleted> context)
        {
            await Repo.Delete(context.Message.Id);
        }
    }
}
