using Api2DataAccess.Repos.Abstract;
using MassTransit;
using Nelibur.ObjectMapper;
using Services.Common.Events.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Core.Consumers.Product
{
    class ProductUpdatedConsumer : IConsumer<ProductUpdated>
    {
        public ProductUpdatedConsumer(IProductRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<ProductUpdated, Api2DataAccess.Entities.Product>();
        }

        public IProductRepository Repo { get; }


        public async Task Consume(ConsumeContext<ProductUpdated> context)
        {
            var entity = TinyMapper.Map<Api2DataAccess.Entities.Product>(context.Message);
            await Repo.Update(entity);

        }
    }
}
