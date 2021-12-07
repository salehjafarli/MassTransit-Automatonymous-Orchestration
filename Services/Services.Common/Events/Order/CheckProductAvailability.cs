using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Events.Order
{
    public class CheckProductAvailability : Event
    {
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
    }
}
