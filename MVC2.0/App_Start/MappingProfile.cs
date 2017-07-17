
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVC2._0.DTO;
using MVC2._0.Models;

namespace MVC2._0.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore()); 



            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<MovieDto,Movie>()
                .ForMember(c=>c.Id,opt=>opt.Ignore());


            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            
        }
    }
}