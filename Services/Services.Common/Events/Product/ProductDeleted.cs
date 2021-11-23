using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Events.Product
{
    public class ProductDeleted : Event
    {
        public int Id { get; set; }
    }
}
