using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Entities
{
    public class Warehouse  
    {
        public Warehouse()
        {
            Products = new List<Product>();
        }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseAdress { get; set; }
        public Company Company { get; set; }
        public List<Product> Products { get; set; } 
    }
}
