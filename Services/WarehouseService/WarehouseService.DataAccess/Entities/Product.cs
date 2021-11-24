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
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public Category Category { get; set; }
    }


    public class WarehouseProduct : Product
    {
        public int Amount { get; set; }
    }
}
