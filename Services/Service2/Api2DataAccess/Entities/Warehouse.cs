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
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public Company Company { get; set; }
        public List<Product> Products { get; set; }
    }
}
