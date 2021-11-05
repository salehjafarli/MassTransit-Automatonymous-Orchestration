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
    public class WarehouseController : ControllerBase
    {
        public WarehouseController(IWarehouseRepository repo)
        {
            Repo = repo;
        }

        public IWarehouseRepository Repo { get; } 

        [HttpPost]
        public async Task<IActionResult> Create(Warehouse w)
        {
            var res = await Repo.Create(w);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await Repo.GetAll();
            return Ok(res);
        }
    }
}
