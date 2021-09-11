using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {
    
    public class BuggyController : BaseController {
        private readonly StoreContext _ctx;

        public BuggyController(StoreContext ctx)
        {
          _ctx= ctx;
        }

        [HttpGet("notfound")]
        public ActionResult  GetNotFound () {

            var thing = _ctx.Products.Find(42);
            if(thing==null) {
                return NotFound(new ApiResponse(404));
            }
            
            return Ok();
           
        }

     [HttpGet("badrequest")]
        public ActionResult<Product> GetBadRequest () {
            return BadRequest(new ApiResponse(400));
           
        }

     [HttpGet("badrequest/{id}")]
        public ActionResult<Product> GetNotFoundRequest(int id) {
            return Ok();
           
        }
      [HttpGet("servererror")]
        public ActionResult<Product> GetServerError () {
               var thing = _ctx.Products.Find(42);
             var thingToReturn = thing.ToString();
            return Ok();
        }
    }
}