using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Core.Models.Commands.Product
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int CategoryId { get; set; }
    }
}
