using Api1DataAccess.EFCore;
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
        public ProductController(Api1DataAccess.EFCore.Api1DbContext con)  
        {
            Con = con;
        }

        public Api1DbContext Con { get; }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await Con.Products.ToListAsync();
            return Ok(list);
        }
    }
}
