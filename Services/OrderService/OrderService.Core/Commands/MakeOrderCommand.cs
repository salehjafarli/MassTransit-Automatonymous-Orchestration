using MediatR;
using Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Commands
{
    public class MakeOrderCommand : IRequest<bool>
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public CardDetails CardDetails { get; set; }
    }
}
