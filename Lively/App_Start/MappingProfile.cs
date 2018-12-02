using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Lively.Models;
using Lively.Dtos;

namespace Lively.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            //Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.ID, opt => opt.Ignore());
        }
    }
}