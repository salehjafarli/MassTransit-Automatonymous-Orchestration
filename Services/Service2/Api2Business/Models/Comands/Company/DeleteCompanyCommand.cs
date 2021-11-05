using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Models.Comands.Company
{
    public class DeleteCompanyCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
