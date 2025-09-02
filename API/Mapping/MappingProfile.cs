using Application.DTOs;
using AutoMapper;
using Domain;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Delivery, DeliveryDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
