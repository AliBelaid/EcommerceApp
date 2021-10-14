using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _data;

        public BasketRepository()
        {
        }

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _data = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _data.KeyDeleteAsync(basketId);
        }

        public async  Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data =await  _data.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null: JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _data.StringSetAsync(basket.Id,
            JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
            if(!created) return null;
            return await GetBasketAsync(basket.Id);
       
        }
    }
}