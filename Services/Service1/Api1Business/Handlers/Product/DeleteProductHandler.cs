using Api1Business.Models.Commands.Product;
using Api1DataAccess.EFCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api1Business.Handlers.Product
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        public DeleteProductHandler(Api1DbContext Context)
        {
            this.Context = Context;
        }

        public Api1DbContext Context { get; }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var tempProduct = new Api1DataAccess.EFCore.Product() { Id = request.Id };
            var res = Context.Products.Remove(tempProduct);
            if (res.State == EntityState.Deleted)
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
