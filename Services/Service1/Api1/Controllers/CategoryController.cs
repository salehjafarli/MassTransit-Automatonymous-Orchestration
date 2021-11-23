using Api1Core.Models.Queries.Category;
using Api1Core.Models.Commands.Category;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        public IMediator Mediator { get; }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand com)
        {
            var res = await Mediator.Send(com);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await Mediator.Send(new GetAllCategoryQuery());
            return Ok(res);
        }
    }
}
