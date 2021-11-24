using MediatR;
using Services.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Core.Models.Queries.Product
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
