using AutoMapper;
using HW_6_2.Data.Entities;
using HW_6_2.Models.DTOs;

namespace HW_6_2.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember("PictureUrl", options
                => options.MapFrom<CatalogItemPictureResolver, string>(catalogItem => catalogItem.PictureFileName));
        CreateMap<CatalogBrand, CatalogBrandDto>();
        CreateMap<CatalogType, CatalogTypeDto>();
    }
}