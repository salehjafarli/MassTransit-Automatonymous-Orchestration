using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Core.Models.Comands.Warehouse
{
    public class UpdateWarehouseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int CompanyId { get; set; }
    }
}
