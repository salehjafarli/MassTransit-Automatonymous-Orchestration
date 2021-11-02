using Api1Business.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Business.Models.Queries.Product
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
