using Api2DataAccess.Entities;
using Api2DataAccess.Repos.Abstract;
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

        public CompanyController(ICompanyRepository repo)
        {
            Repo = repo;
        }

        public ICompanyRepository Repo { get; }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await Repo.GetAll();
            return Ok(res);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await Repo.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company c)
        {
            var res = await Repo.Create(c);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Company c)
        {
            var res = await Repo.Update(c);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await Repo.Delete(id);
            return Ok(res);
        }
    }
}
