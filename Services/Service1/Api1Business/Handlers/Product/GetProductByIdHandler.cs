using Api1Business.Models.Queries.Product;
using Api1Business.Models.Response;
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
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        public GetProductByIdHandler(Api1DbContext Context)
        {
            this.Context = Context;
        }

        public Api1DbContext Context { get; }
        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await Context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == request.Id);
            TinyMapper.Bind<Api1DataAccess.EFCore.Product, ProductResponse>(cfg => 
            {
                cfg.Ignore(x => x.Category.Products);
            });
            return TinyMapper.Map<ProductResponse>(product);
                                                   
        }
    }
}
