using Api1Business.Models.Queries.Category;
using Api1DataAccess.EFCore;
using MediatR;
using Nelibur.ObjectMapper;
using Services.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api1Business.Handlers.Category
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
    {
        public GetCategoryByIdHandler(Api1DbContext Context)
        {
            this.Context = Context;
            TinyMapper.Bind<Api1DataAccess.EFCore.Category, CategoryResponse>();
        }

        public Api1DbContext Context { get; }
        public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var res = Context.Categories.FirstOrDefault(x => x.Id == request.Id);
            return TinyMapper.Map<CategoryResponse>(res);
        }
    }
}
