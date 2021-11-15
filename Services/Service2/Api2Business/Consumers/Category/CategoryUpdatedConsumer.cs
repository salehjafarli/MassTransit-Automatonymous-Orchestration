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
    class CategoryUpdatedConsumer : IConsumer<CategoryUpdated>
    {
        public CategoryUpdatedConsumer(ICategoryRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<CategoryUpdated, Api2DataAccess.Entities.Category>();
        }

        public ICategoryRepository Repo { get; }
        public async Task Consume(ConsumeContext<CategoryUpdated> context)
        {
            var entity = TinyMapper.Map<Api2DataAccess.Entities.Category>(context.Message);
            await Repo.Update(entity);
        }
    }
}
