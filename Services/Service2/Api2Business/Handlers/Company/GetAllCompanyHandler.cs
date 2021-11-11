using Api2Business.Models.Queries;
using Api2Business.Models.Queries.Company;
using Api2DataAccess.Repos.Abstract;
using MediatR;
using Nelibur.ObjectMapper;
using Services.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api2Business.Handlers.Company
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyQuery, ICollection<CompanyResponse>>
    {
        public GetAllCompanyHandler(ICompanyRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<Api2DataAccess.Entities.Company, CompanyResponse>();
        }

        public ICompanyRepository Repo { get; }

        public async Task<ICollection<CompanyResponse>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var list = await Repo.GetAll();
            var res = new List<CompanyResponse>();
            foreach (var item in list)
            {
                res.Add(TinyMapper.Map<CompanyResponse>(item));
            }
            return res;
        }
    }
}
