using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IMediator Mediator { get; }

        public OrderController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrder(MakeOrderCommand makeOrder)
        {
            var res = await Mediator.Send(makeOrder);
            return Ok(res);
        }
    }
}
