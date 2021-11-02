using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Business.Models.Commands.Product
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public int CategoryId { get; set; }
    }
}
