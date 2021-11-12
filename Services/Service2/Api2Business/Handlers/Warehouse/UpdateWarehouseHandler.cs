using Api2Business.Models.Comands.Warehouse;
using Api2DataAccess.Repos.Abstract;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api2Business.Handlers.Warehouse
{
    public class UpdateWarehouseHandler : IRequestHandler<UpdateWarehouseCommand,bool>
    {
        public UpdateWarehouseHandler(IWarehouseRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<UpdateWarehouseCommand, Api2DataAccess.Entities.Warehouse>();
        }

        public IWarehouseRepository Repo { get; }

        public async Task<bool> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var entity = TinyMapper.Map<Api2DataAccess.Entities.Warehouse>(request);
            return await Repo.Update(entity);
        }

        
    }
}
