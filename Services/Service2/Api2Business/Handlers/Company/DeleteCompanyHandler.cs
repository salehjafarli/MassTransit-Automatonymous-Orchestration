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
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        public DeleteCompanyHandler(ICompanyRepository Repo)
        {
            this.Repo = Repo;
        }

        public ICompanyRepository Repo { get; }
        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            return await Repo.Delete(request.Id);
        }
    }
}
