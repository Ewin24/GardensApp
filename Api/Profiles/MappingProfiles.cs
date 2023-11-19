using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Boss, BossDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Office, OfficeDto>().ReverseMap();
            CreateMap<OrderDetail ,OrderDetailDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<Payment ,PaymentDto>().ReverseMap();
            CreateMap<Product,ProducDto>().ReverseMap();
            CreateMap<ProductLine,ProductLineDto>().ReverseMap();
            CreateMap<Proveedor,ProveedorDto>().ReverseMap();
            CreateMap<State,StateDto>().ReverseMap();
            CreateMap<TypeContact,TypeContactDto>().ReverseMap();
        }
    }
}