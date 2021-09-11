using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
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
        private readonly IGenericRepository<Product> repoProduct;
        private readonly IGenericRepository<ProductBrand> repProductBrand;
        private readonly IGenericRepository<ProductType> repoProductType;
        private readonly IMapper _mapper;

        public ProductsController (IGenericRepository<Product> repoProduct ,
         IGenericRepository<ProductBrand> repProductBrand ,
        IGenericRepository<ProductType>repoProductType, IMapper mapper ) {
            this.repoProduct = repoProduct;
            this.repProductBrand = repProductBrand;
            this.repoProductType = repoProductType;
         _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()  {
           var spec = new ProductsWithTypeAndBrandSpecifications(); 
           var products= await repoProduct.ListAsync(spec);
         return  Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products)); 
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct (int id) {

            var spec = new ProductsWithTypeAndBrandSpecifications(id); 
            var product = await repoProduct.GetEntityWithSpec(spec);
               
            return Ok( _mapper.Map<Product,ProductToReturnDto>(product) );
 
        }

         [HttpGet("brands")]
        public async Task<ActionResult<Product>> GetProductBrand () {
          var pro = await repProductBrand.ListAllAsync() ;

          return Ok(pro);
        }
        
          [HttpGet("types")]
        public async Task<ActionResult<Product>> GetProductType () {

            var pro = await repoProductType.ListAllAsync() ;

            return Ok(pro);
         }
    }}