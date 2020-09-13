using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Paranoid.Models;
using Paranoid.DTOs;

namespace Paranoid.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}