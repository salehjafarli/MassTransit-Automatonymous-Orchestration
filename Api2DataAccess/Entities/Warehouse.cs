using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Entities
{
    public class Warehouse  : BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public Company Company { get; set; }
        public List<Product> Products { get; set; }
    }
}
