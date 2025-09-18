using AutoMapper;
using DTLayer.Entities;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.maaper
{
    public  class AppMappingProfile : Profile
    {

        public AppMappingProfile() 
        {
            CreateMap<addUpdateSpecilizesDto, Specilzeations>();

            CreateMap<Specilzeations, addUpdateSpecilizesDto>();

            //CreateMap<Items, UpdateItemsDto>();

            CreateMap<Items, ItemsDtos>();
            CreateMap<ItemsDtos, Items>().
                ForMember(x => x.specilize, y => y.Ignore())
                .ForMember(x=>x.specilizeID,y=>y.Ignore())
                .ForMember(x => x.itemID, y => y.Ignore());

            //CreateMap<UpdateItemsDto, Items>()
            //    .ForMember(x => x.specilize, y => y.Ignore()); ;

            CreateMap<UpdateItemsDto, Items>()
            .ForMember(dest => dest.itemID, opt => opt.MapFrom(src => src.itemID))
            .ForMember(dest => dest.itemName, opt => opt.MapFrom(src => src.itemName))
            .ForMember(dest => dest.specilizeID, opt => opt.Ignore())
            .ForMember(dest => dest.specilize, opt => opt.Ignore());


            CreateMap<UpdateItemsWithSpecilzeDtos, Items>()
            .ForMember(dest => dest.itemID, opt => opt.MapFrom(src => src.item.itemID))
            .ForMember(dest => dest.itemName, opt => opt.MapFrom(src => src.item.itemName))
            .ForMember(dest => dest.specilizeID, opt => opt.Ignore())
            .ForMember(dest => dest.specilize, opt => opt.Ignore());

            CreateMap<UpdateItemsWithSpecilzeDtos, Specilzeations>()
            .ForMember(dest => dest.specilizeId, opt => opt.MapFrom(x => x.specilze.specilizeId))
            .ForMember(dest => dest.specilizeName, opt => opt.MapFrom(x => x.specilze.specilizeName));


            CreateMap<Items, FindItemsDtos>()
    .ForMember(dest => dest.itemID, opt => opt.MapFrom(src => src.itemID))
    .ForMember(dest => dest.itemName, opt => opt.MapFrom(src => src.itemName))
    .ForMember(dest => dest.specilizeId, opt => opt.MapFrom(src => src.specilizeID))
    .ForMember(dest => dest.specilizeName, opt => opt.MapFrom(src => src.specilize.specilizeName));




            //CreateMap<>


        }

    }
}
