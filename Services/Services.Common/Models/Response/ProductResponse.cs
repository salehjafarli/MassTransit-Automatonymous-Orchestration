using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Models.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public virtual CategoryResponse Category { get; set; }
    }
}
