using Api2Business.Models.Comands;
using Api2Business.Models.Comands.Warehouse;
using Api2Business.Models.Queries.Warehouse;
using Api2DataAccess.Entities;
using Api2DataAccess.Repos.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {


        public WarehouseController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        public IMediator Mediator { get; }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await Mediator.Send(new GetAllWarehouseQuery());
            return Ok(res);
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await Mediator.Send(new GetWarehouseByIdQuery(id));
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWarehouseCommand com)
        {
            var res = await Mediator.Send(com);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateWarehouseCommand com)
        {
            var res = await Mediator.Send(com);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(CommonDeleteCommand com)
        {
            var res = await Mediator.Send(com);
            return Ok(res);
        }
    }
}
