using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Business.Models.Queries
{
    public class CommonQuery<T> : IRequest<ICollection<T>>
    {
    }
}
