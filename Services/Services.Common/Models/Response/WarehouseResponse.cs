using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Models.Response
{
    public class WarehouseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public CompanyResponse Company { get; set; }
        public List<ProductResponse> Products { get; set; }
    }
}
