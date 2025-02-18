using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
                //.ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();

            Mapper.CreateMap<MoviesDTO, Movies>();
            Mapper.CreateMap<Movies, MoviesDTO>();
        }
    }
}