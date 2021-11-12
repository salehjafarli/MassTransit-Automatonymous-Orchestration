using Api2DataAccess.Repos.Abstract;
using MassTransit;
using Nelibur.ObjectMapper;
using Services.Common.Events.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Consumers.Category
{
    class CategoryCreatedConsumer : IConsumer<CategoryCreated>
    {
        public CategoryCreatedConsumer(ICategoryRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<CategoryCreated, Api2DataAccess.Entities.Category>();
        }

        public ICategoryRepository Repo { get; }

        public async Task Consume(ConsumeContext<CategoryCreated> context)
        {
            var entity =  TinyMapper.Map<Api2DataAccess.Entities.Category>(context.Message);

            await Repo.Create(entity);
        }
    }
}
