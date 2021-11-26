using Services.Common.Enum;
using Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Events.Order
{
    public class OrderCreated : Event
    {
        public OrderState OrderState { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public CardDetails CardDetails { get; set; }
    }
}
