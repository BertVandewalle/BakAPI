﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakAPI.Data;
using BakAPI.Models;

namespace BakAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<Player, PlayerDTO>().ReverseMap();
            CreateMap<Player, CreatePlayerDTO>().ReverseMap();
            CreateMap<Game, GameDTO>().ReverseMap();
            CreateMap<Game, CreateGameDTO>().ReverseMap();
            CreateMap<GamePlayer, GamePlayerDTO>().ReverseMap();
            CreateMap<GamePlayer, CreateGamePlayerDTO>().ReverseMap();


            //CreateMap<ApiUser, LoginUserDTO>().ReverseMap();
        }
    }
}
