using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Core.Models.Comands
{
    public class CommonDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
