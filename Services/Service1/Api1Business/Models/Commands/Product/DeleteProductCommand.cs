using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Core.Models.Commands.Product
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
