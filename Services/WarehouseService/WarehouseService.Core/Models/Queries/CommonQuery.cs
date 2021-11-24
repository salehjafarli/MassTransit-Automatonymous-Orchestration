using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Core.Models.Queries
{
    public class CommonQuery<T> : IRequest<ICollection<T>>
    {
    }
}
