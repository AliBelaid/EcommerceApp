using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers {

  public class ProductWebController : BaseController {

    private readonly IProductRepository _repoProduct;
    private readonly StoreContext _ctx;
        private readonly IGenericRepository<ProductWebSite> _repoProductF;
        private readonly IMapper _mapper;
    public ProductWebController (IProductRepository repoProduct, StoreContext ctx,

       IGenericRepository<ProductWebSite>  repoProductF , 
      IMapper mapper) {
      _repoProduct = repoProduct;
      _ctx = ctx;
            _repoProductF = repoProductF;
            _mapper = mapper;

    }

    // [HttpPost]
    // public async Task<ActionResult<Order>> CreateProductWeb (OrderDto orderDto) {
    //     var email = HttpContext.User.RetrieveEmailFormPrincipal ();
    // //    var address = _mapper.Map<AddressDto, Address> (orderDto.shipToAddress);
    //  //   var order = await _orderService.CreateOrderAsync(email, orderDto.deliveryMethodId, orderDto.basketId, address);
    //  v
    //     if (order == null) return BadRequest (new ApiResponse (400, "Problam createing order"));
    //     return Ok (order);

    // }

    [HttpGet ()]
    public async Task<ActionResult<IReadOnlyList<ProductWebSite>>> GetProducts () {

        var spec = new ProductsWebSiteWithTypeAndBrandSpecifications(); 

      var products = await _ctx.ProductsWebSite.ToListAsync(); //--await _repoProduct.GetProductsAsync();
var rhrfh = await _repoProductF.ListAsync(spec);
      return Ok (rhrfh);
    }

    [HttpGet ("{id}")]
    [ProducesResponseType ((StatusCodes.Status200OK))]
    [ProducesResponseType (typeof (ApiResponse), (StatusCodes.Status404NotFound))]

    public async Task<ActionResult<ProductWebSite>> GetProduct (int id) {

        var spec = new ProductsWebSiteWithTypeAndBrandSpecifications(id); 
      // _ctx.ProductsWebSite.SingleOrDefaultAsync(i => i.Id == id); // await _repoProduct.GetProductByIdAsync(id);
      var product =await _repoProductF.GetEntityWithSpec(spec);
     
     
      if (product == null) {
        return NotFound (new ApiResponse (404));
      }
      return Ok (product);

    }

    [HttpPost]
     public async Task<ActionResult<ProductWebDto>> AddProduct (ProductWebDto productWebDto) {

      //   var spec = new ProductsWebSiteWithTypeAndBrandSpecifications(id); 

       var checkExist = await _ctx.ProductsWebSite.AnyAsync (i => i.title == productWebDto.title);
      if (checkExist) return BadRequest (new ApiResponse (404));
      var item = _mapper.Map<ProductWebDto, ProductWebSite> (productWebDto);
      await _ctx.ProductsWebSite.AddAsync (item);
      await _ctx.SaveChangesAsync ();

      return Ok (item);

    }

  }
}