﻿using MediatR;
using Services.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2Core.Models.Queries.Warehouse
{
    public class GetWarehouseByIdQuery : IRequest<WarehouseResponse>
    {
        public GetWarehouseByIdQuery(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
