using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.identity;
using Core.Entities.OrderAggregate;

namespace API.Helpers {
    public class MappingProfiles : Profile {
        public MappingProfiles () {
            CreateMap<Product, ProductToReturnDto> ().ForMember (x => x.ProductBrand, o =>
                o.MapFrom (s => s.ProductBrand.Name)).ForMember (x => x.ProductType, o =>
                o.MapFrom (s => s.ProductType.Name)).ForMember (x => x.PictureUrl, o =>
                o.MapFrom<ProductUrlResolver> ());
            CreateMap<Core.Entities.identity.Address, AddressDto> ().ReverseMap ();
            CreateMap<CustomerBasketDto, CustomerBasket> ();
            CreateMap<BasketItemDto, BasketItem> ();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address> ();

            CreateMap<Order,OrderToReturnDto>().
            ForMember(a=>a.DelivaryMethod, o=>o.MapFrom(s =>s.DelivaryMethod.ShortName)).
             ForMember(a=>a.ShippingPrice, o=>o.MapFrom(s =>s.DelivaryMethod.Price));
            CreateMap<OrderItem,OrderItemDto>()
            .ForMember(e =>e.PictureUrl, u =>u.MapFrom(o => o.ItemOrdered.PictureUrl))
            .ForMember(e =>e.ProductId, u =>u.MapFrom(o => o.ItemOrdered.ProductItemId))
            .ForMember(e =>e.ProductName, u =>u.MapFrom(o => o.ItemOrdered.ProductName))
                    .ForMember(e =>e.PictureUrl, u =>u.MapFrom<OrderUrlResolver>()); 
        }
    }
}