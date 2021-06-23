using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dto;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.App_Start
{
    public class MappingProfile  : Profile
    {

        public MappingProfile()
        {

            Mapper.CreateMap<Customeer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customeer>();


            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<MemberShipTypeDto, MemberShipType>();


            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();

            
        }
    }
}