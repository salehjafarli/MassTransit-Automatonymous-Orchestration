using Api2Core.Models.Comands.Warehouse;
using Api2DataAccess.Repos.Abstract;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api2Core.Handlers.Warehouse
{
    class CreateWarehouseHandler : IRequestHandler<CreateWarehouseCommand, bool>
    {
        public CreateWarehouseHandler(IWarehouseRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<CreateWarehouseCommand,Api2DataAccess.Entities.Warehouse>();
        }

        public IWarehouseRepository Repo { get; }

        public async Task<bool> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var entity = TinyMapper.Map<Api2DataAccess.Entities.Warehouse>(request);
            entity.Company = new Api2DataAccess.Entities.Company() { Id = request.CompanyId };
            return await Repo.Create(entity);
        }
    }
}
