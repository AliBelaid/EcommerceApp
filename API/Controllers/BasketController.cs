using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _map;

        public BasketController(IBasketRepository basketRepository ,IMapper map)
        {
            _basketRepository = basketRepository;
            _map = map;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketId(string id) {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
               }   

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket) {
            var customerBasket = _map.Map<CustomerBasketDto,CustomerBasket>(basket);
            
            var basketSave = await _basketRepository.UpdateBasketAsync(customerBasket);
            return Ok(basketSave);
               }  


                [HttpDelete]
        public async Task  DeleteBasketId(string id) {
              await _basketRepository.DeleteBasketAsync(id);
             
               }                         
    }
}