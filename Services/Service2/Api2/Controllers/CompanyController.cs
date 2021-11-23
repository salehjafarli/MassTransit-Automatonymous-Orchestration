using Api2Core.Models.Comands;
using Api2Core.Models.Comands.Company;
using Api2Core.Models.Queries;
using Api2Core.Models.Queries.Company;
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
    public class CompanyController : ControllerBase
    {

        public CompanyController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        public IMediator Mediator { get; }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await Mediator.Send(new GetCompanyByIdQuery(id));
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await Mediator.Send(new GetAllCompanyQuery());
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCommand c)
        {
            var res = await Mediator.Send(c);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCompanyCommand c)
        {
            var res = await Mediator.Send(c);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(CommonDeleteCommand c)
        {
            var res = await Mediator.Send(c);
            return Ok(res);
        }
    }
}
