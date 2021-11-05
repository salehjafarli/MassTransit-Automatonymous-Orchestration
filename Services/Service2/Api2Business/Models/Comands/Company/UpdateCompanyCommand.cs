using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Models.Comands.Company
{
    public class UpdateCompanyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
