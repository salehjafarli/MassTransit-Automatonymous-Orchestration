using Api1Business.Models.Commands.Category;
using Api1DataAccess.EFCore;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using Services.Common.Events.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api1Business.Handlers.Category
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand,bool>
    {
        public CreateCategoryHandler(Api1DbContext Context, IBusControl Bus)
        {
            this.Context = Context;
            this.Bus = Bus;
            TinyMapper.Bind<CreateCategoryCommand, Api1DataAccess.EFCore.Category>();
            TinyMapper.Bind<Api1DataAccess.EFCore.Category, CategoryCreated>();
        }

        public Api1DbContext Context { get; }
        public IBusControl Bus { get; }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = TinyMapper.Map<Api1DataAccess.EFCore.Category>(request);
            var res = Context.Categories.Add(category);

            if (res.State == EntityState.Added)
            {
                await Context.SaveChangesAsync();
                var createdEvent = TinyMapper.Map<CategoryCreated>(category);
                await Bus.Publish(createdEvent);
                return true;

            }
            return false;
        }
    }
}
