using Api1Core.Models.Commands.Product;
using Api1Core.Models.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public IMediator Mediator { get; set; }
        public ProductController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await Mediator.Send(new GetProductByIdQuery(id));
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}
