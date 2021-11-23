using Api2Core.Models.Comands;
using Api2DataAccess.Repos.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api2Core.Handlers.Warehouse
{
    public class DeleteWarehouseHandler : IRequestHandler<CommonDeleteCommand,bool>
    {
        public DeleteWarehouseHandler(IWarehouseRepository Repo)
        {
            this.Repo = Repo;
        }

        public IWarehouseRepository Repo { get; }

        public async Task<bool> Handle(CommonDeleteCommand request, CancellationToken cancellationToken)
        {
            return await Repo.Delete(request.Id);
        }
    }
}
