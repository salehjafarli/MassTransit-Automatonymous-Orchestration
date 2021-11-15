using Api2DataAccess.Repos.Abstract;
using MassTransit;
using MediatR;
using Nelibur.ObjectMapper;
using Services.Common.Events.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Consumers.Product
{
    class ProductCreatedConsumer : IConsumer<ProductCreated>
    {
        public ProductCreatedConsumer(IProductRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<ProductCreated,Api2DataAccess.Entities.Product>();
        }

        public IProductRepository Repo { get; }

        public async Task Consume(ConsumeContext<ProductCreated> context)
        {
            var entity  = TinyMapper.Map<Api2DataAccess.Entities.Product>(context.Message);
            await Repo.Create(entity);
            
        }
    }
}
