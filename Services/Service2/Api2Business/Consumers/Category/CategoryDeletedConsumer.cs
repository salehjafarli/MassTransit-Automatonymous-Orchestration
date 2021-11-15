using Api2DataAccess.Repos.Abstract;
using MassTransit;
using Services.Common.Events.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Consumers.Category
{
    class CategoryDeletedConsumer : IConsumer<CategoryDeleted>
    {
        public CategoryDeletedConsumer(ICategoryRepository Repo)
        {
            this.Repo = Repo;
        }

        public ICategoryRepository Repo { get; }

        public async Task Consume(ConsumeContext<CategoryDeleted> context)
        {
            int id = context.Message.Id;
            await Repo.Delete(id);
        }
    }
}
