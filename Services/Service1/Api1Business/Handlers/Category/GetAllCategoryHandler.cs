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
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, ICollection<CategoryResponse>>
    {
        public GetAllCategoryHandler(Api1DbContext Context)
        {
            this.Context = Context;
            TinyMapper.Bind<Api1DataAccess.EFCore.Category,CategoryResponse>();
        }

        public Api1DbContext Context { get; }

        public async Task<ICollection<CategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var data = Context.Categories;
            var response = new List<CategoryResponse>();
            foreach (var item in data)
            {
                response.Add(TinyMapper.Map<CategoryResponse>(item));
            }
            return response;


        }
    }
}
