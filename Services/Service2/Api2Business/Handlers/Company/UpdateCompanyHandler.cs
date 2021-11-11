using Api2Business.Models.Comands.Company;
using Api2DataAccess.Repos.Abstract;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api2Business.Handlers.Company
{
    class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        public UpdateCompanyHandler(ICompanyRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<UpdateCompanyCommand, Api2DataAccess.Entities.Company>();
        }

        public ICompanyRepository Repo { get; }
        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = TinyMapper.Map<Api2DataAccess.Entities.Company>(request);
            return await Repo.Update(company);
        }
    }
}
