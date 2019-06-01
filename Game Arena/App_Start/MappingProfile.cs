using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Game_Arena.Models;
using Game_Arena.Dtos;

namespace Game_Arena.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //AutoMapper uses reflection to scan their properties and maps based on their names 
            Mapper.CreateMap<Customer, CustomerDto>(); //prevents id change exception and ignores id
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Game, GameDto>();
            Mapper.CreateMap<GameDto, Game>()
                .ForMember(g => g.Id, opt => opt.Ignore());

            Mapper.CreateMap<RentedGames, RentedGamesDto>();
            Mapper.CreateMap<RentedGamesDto, RentedGames>()
                .ForMember(rg => rg.Id, opt => opt.Ignore());

            Mapper.CreateMap<RentedGames, RentedGamesDtoSingle>();


        }
    }
}