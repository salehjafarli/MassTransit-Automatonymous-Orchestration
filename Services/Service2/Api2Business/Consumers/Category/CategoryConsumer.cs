using Api2DataAccess.Repos.Abstract;
using MassTransit;
using Nelibur.ObjectMapper;
using Services.Common.Events.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Core.Consumers.Category
{
    class CategoryConsumer : IConsumer<CategoryCreated>, IConsumer<CategoryUpdated>, IConsumer<CategoryDeleted>
    {
        public CategoryConsumer(ICategoryRepository Repo)
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

        public async Task Consume(ConsumeContext<CategoryUpdated> context)
        {
            var entity = TinyMapper.Map<Api2DataAccess.Entities.Category>(context.Message);
            await Repo.Update(entity);
        }

        public async Task Consume(ConsumeContext<CategoryDeleted> context)
        {
            int id = context.Message.Id;
            await Repo.Delete(id);
        }
    }
}
