using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductsController : ControllerBase {

        private readonly StoreContext _ctx;

        public ProductsController (StoreContext ctx) {
            _ctx = ctx;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()  {

            return Ok( await _ctx.Products.ToListAsync());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Product>> GetProduct (int id) {
            var pro = await _ctx.Products.FirstOrDefaultAsync(i=>i.Id==id) ;

            return Ok(pro);
        }
    }}