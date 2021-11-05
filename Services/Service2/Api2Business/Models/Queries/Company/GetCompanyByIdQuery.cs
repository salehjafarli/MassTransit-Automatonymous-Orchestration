using MediatR;
using Services.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Business.Models.Queries.Company
{
    public class GetCompanyByIdQuery : IRequest<CompanyResponse>
    {
        public int Id { get; set; }
    }
}
