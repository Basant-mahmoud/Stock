using AutoMapper;
using Stock.Stock.Application.Dto;
using Stock.Stock.Domain.Models;

namespace Stock.Stock.Domain.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower()));
            CreateMap<Item, GetItemDto>().ReverseMap();
        }
    }
}


