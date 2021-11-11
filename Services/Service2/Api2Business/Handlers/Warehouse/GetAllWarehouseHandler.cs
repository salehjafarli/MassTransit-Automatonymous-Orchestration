using Api2Business.Models.Queries.Warehouse;
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
    public class GetAllWarehouseHandler : IRequestHandler<GetAllWarehouseQuery, ICollection<WarehouseResponse>>
    {
        public GetAllWarehouseHandler(IWarehouseRepository Repo)
        {
            this.Repo = Repo;
            TinyMapper.Bind<Api2DataAccess.Entities.Warehouse, WarehouseResponse>();
        }

        public IWarehouseRepository Repo { get; }

        public async Task<ICollection<WarehouseResponse>> Handle(GetAllWarehouseQuery request, CancellationToken cancellationToken)
        {
            var data = await Repo.GetAll();
            var res =new  List<WarehouseResponse>();
            foreach (var item in data)
            {
                res.Add(TinyMapper.Map<WarehouseResponse>(item));
            }
            return res;
        }
    }
}
