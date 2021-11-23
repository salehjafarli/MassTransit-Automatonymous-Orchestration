using MediatR;
using Services.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Core.Models.Queries.Category
{
    public class GetCategoryByIdQuery : IRequest<CategoryResponse>
    {
        public int Id { get; set; }

    }
}
