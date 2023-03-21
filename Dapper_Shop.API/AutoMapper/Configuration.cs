using AutoMapper;
using Dapper_Shop.Domain.Commands;
using Dapper_Shop.Domain.Entities;

namespace Dapper_Shop.API.AutoMapper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<NewShop, Shop>().ReverseMap();
            CreateMap<NewCustomer, Customer>().ReverseMap();
            CreateMap<NewVehicle, Vehicle>().ReverseMap();
        }
    }
}
