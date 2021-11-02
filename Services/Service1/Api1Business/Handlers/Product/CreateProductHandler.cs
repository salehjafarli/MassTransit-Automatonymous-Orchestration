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
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        public CreateProductHandler(Api1DbContext Context)
        {
            this.Context = Context;
        }

        public Api1DbContext Context { get; }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //implement masstransit logic for syncing microservice databases
            TinyMapper.Bind<CreateProductCommand, Api1DataAccess.EFCore.Product>();
            var TempProduct = TinyMapper.Map<Api1DataAccess.EFCore.Product>(request);
            var res = Context.Products.Add(TempProduct);
            if (res.State == EntityState.Added)
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
