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
    class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        public DeleteCategoryHandler(Api1DbContext Context, IBusControl Bus)
        {
            this.Context = Context;
            this.Bus = Bus;
            TinyMapper.Bind<DeleteCategoryCommand, Api1DataAccess.EFCore.Category>();
            TinyMapper.Bind<DeleteCategoryCommand, CategoryDeleted>();
        }

        public Api1DbContext Context { get; }
        public IBusControl Bus { get; }
        public async  Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = TinyMapper.Map<Api1DataAccess.EFCore.Category>(request);
            var res = Context.Categories.Remove(entity);
            if (res.State == EntityState.Deleted)
            {
                var @event = TinyMapper.Map<CategoryDeleted>(request);
                await Bus.Publish(@event);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
