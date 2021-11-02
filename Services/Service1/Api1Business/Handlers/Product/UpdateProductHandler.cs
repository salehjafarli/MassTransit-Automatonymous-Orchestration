using Api1Business.Models.Commands.Product;
using Api1DataAccess.EFCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api1Business.Handlers.Product
{
    public class  UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        public UpdateProductHandler(Api1DbContext Context)
        {
            this.Context = Context;
        }

        public Api1DbContext Context { get; }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            TinyMapper.Bind<UpdateProductCommand, Api1DataAccess.EFCore.Product>();
            var TempProduct = TinyMapper.Map<Api1DataAccess.EFCore.Product>(request);
            var res = Context.Products.Update(TempProduct);
            if (res.State == EntityState.Modified)
            {
                await Context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
