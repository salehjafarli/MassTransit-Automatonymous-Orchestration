using Api2Business.Models.Queries.Warehouse;
using Api2DataAccess.Entities;
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


namespace Api2Business.Handlers.Warehouse
{
    class GetWarehouseByIdHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseResponse>
    {
        public GetWarehouseByIdHandler(IWarehouseRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<Api2DataAccess.Entities.Warehouse, WarehouseResponse>();
        }

        public IWarehouseRepository Repo { get; }

        public async Task<WarehouseResponse> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await Repo.GetById(request.Id);
            return  entity is null ? null : TinyMapper.Map<WarehouseResponse>(entity);
        }
    }
}
