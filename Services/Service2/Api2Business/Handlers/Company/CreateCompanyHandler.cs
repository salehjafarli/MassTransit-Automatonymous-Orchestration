using Api2Business.Models.Comands.Company;
using Api2DataAccess.Repos.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api2Business.Handlers.Company
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand,bool>
    {
        public CreateCompanyHandler(ICompanyRepository Repo)
        {
            this.Repo = Repo;
        }

        public ICompanyRepository Repo { get; }

        public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Api2DataAccess.Entities.Company()
            {
                CompanyName = request.Name
            };
            return await Repo.Create(company);
        }
    }
}
