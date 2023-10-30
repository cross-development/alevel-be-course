﻿using AutoMapper;
using HW_6_2.Data.Entities;
using HW_6_2.Models.DTOs;
using HW_6_2.Models.Requests;

namespace HW_6_2.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddItemRequest, CatalogItem>();
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember("PictureUrl", options =>
                options.MapFrom<CatalogItemPictureResolver, string>(catalogItem => catalogItem.PictureFileName));
        
        CreateMap<AddBrandRequest, CatalogBrand>();
        CreateMap<CatalogBrand, CatalogBrandDto>();

        CreateMap<AddTypeRequest, CatalogType>();
        CreateMap<CatalogType, CatalogTypeDto>();
    }
}