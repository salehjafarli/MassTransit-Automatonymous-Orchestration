
using Api2Core.Models.Queries.Company;
using Api2DataAccess.Repos.Abstract;
using MediatR;
using Nelibur.ObjectMapper;
using Services.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api2Core.Handlers.Company
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery,CompanyResponse>
    {
        public GetCompanyByIdHandler(ICompanyRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<Api2DataAccess.Entities.Company, CompanyResponse>();
        }

        public ICompanyRepository Repo { get; }

        public async Task<CompanyResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await Repo.GetById(request.Id);
            if (entity is null) return null;
            var response = TinyMapper.Map<CompanyResponse>(entity);
            return response;
        }
    }
}
