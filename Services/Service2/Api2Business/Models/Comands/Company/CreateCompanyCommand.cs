using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Core.Models.Comands.Company
{
    public class CreateCompanyCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
