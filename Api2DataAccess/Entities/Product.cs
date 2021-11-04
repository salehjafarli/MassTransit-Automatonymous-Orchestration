using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Entities
{
    public class Product 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
        public Category Category { get; set; }
    }
}
