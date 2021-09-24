using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace API.Controllers {
 
    public class ProductsController : BaseController {
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
        public async Task<ActionResult<IReadOnlyList<Pagination<ProductToReturnDto>>>> GetProducts([FromQuery]ProductSpecParams productParams)  {
           var spec = new ProductsWithTypeAndBrandSpecifications(productParams); 

           var countSpec = new ProductWithFiltersForCountSpecification(productParams);
           var totalItems= await repoProduct.CountAsync(countSpec);

           var products= await repoProduct.ListAsync(spec);
           var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products);
         return  Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,
         productParams.PageSize,totalItems,data)); 
        }

        [HttpGet ("{id}")]
        [ProducesResponseType((StatusCodes.Status200OK))]
        [ProducesResponseType(typeof(ApiResponse),(StatusCodes.Status404NotFound))]
 
        public async Task<ActionResult<ProductToReturnDto>> GetProduct (int id) {

            var spec = new ProductsWithTypeAndBrandSpecifications(id); 
            var product = await repoProduct.GetEntityWithSpec(spec);
            if(product==null) {
              return NotFound(new ApiResponse(404));
            }
            return  Ok(_mapper.Map<Product,ProductToReturnDto>(product)); 
     
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