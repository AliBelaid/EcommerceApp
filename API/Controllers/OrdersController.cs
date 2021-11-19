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
using Core.Entities.OrderAggregate;
using Core.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {
    [Authorize]

    public class OrdersController : BaseController {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController (IOrderService orderService, IMapper mapper) {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder (OrderDto orderDto) {
            var email = HttpContext.User.RetrieveEmailFormPrincipal ();
            var address = _mapper.Map<AddressDto, Address> (orderDto.shipToAddress);
            var order = await _orderService.CreateOrderAsync (email, orderDto.deliveryMethodId, orderDto.basketId, address);
            if (order == null) return BadRequest (new ApiResponse (400, "Problam createing order"));
            return Ok (order);

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser () {

            var email = HttpContext.User.RetrieveEmailFormPrincipal ();
            var order = await _orderService.GetOrderForUserAsync (email);
            return Ok (_mapper.Map<IReadOnlyList<Order>,IReadOnlyList<OrderToReturnDto>>(order));

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdAsync(int id){
         var email = HttpContext.User.RetrieveEmailFormPrincipal ();
            var order = await _orderService.GetOrderByIdAsync(id,email);

            if(order==null) return NotFound(new ApiResponse(404));
            return Ok (_mapper.Map<Order,OrderToReturnDto>(order));
        }

    [HttpGet("deliveryMethods")]

        public async Task<ActionResult<DelivaryMethod>> GetDeliveryMethods(int id){
            return Ok (await _orderService.GetDelivaryMethodAsync());
        }


    }
}