using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Models.Comands.Warehouse
{
    public class CreateWarehouseCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public int CompanyId { get; set; }
    }
}
