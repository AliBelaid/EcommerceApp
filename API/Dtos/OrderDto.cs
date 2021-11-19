using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrderDto
    {
        public string basketId { get; set; }
                public int deliveryMethodId { get; set; }

                public AddressDto shipToAddress { get; set; }

    }
}

