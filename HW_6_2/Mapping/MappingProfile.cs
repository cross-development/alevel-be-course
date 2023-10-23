using AutoMapper;
using HW_6_2.Data.Entities;
using HW_6_2.Models.DTOs;

namespace HW_6_2.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember("PictureUrl", options =>
                options.MapFrom<CatalogItemPictureResolver, string>(catalogItem => catalogItem.PictureFileName));
        CreateMap<CatalogItemDto, CatalogItem>()
            .ForMember("PictureFileName", options =>
                options.MapFrom<CatalogItemFileResolver, string>(catalogItem => catalogItem.PictureUrl));

        CreateMap<CatalogBrand, CatalogBrandDto>();
        CreateMap<CatalogBrandDto, CatalogBrand>();

        CreateMap<CatalogType, CatalogTypeDto>();
        CreateMap<CatalogTypeDto, CatalogType>();
    }
}