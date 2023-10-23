using Microsoft.Extensions.Options;
using AutoMapper;
using HW_6_2.Models.DTOs;
using HW_6_2.Data.Entities;
using HW_6_2.Configurations;

namespace HW_6_2.Mapping;

public class CatalogItemPictureResolver : IMemberValueResolver<CatalogItem, CatalogItemDto, string, object>
{
    private readonly CatalogConfiguration _config;

    public CatalogItemPictureResolver(IOptions<CatalogConfiguration> config)
    {
        _config = config.Value;
    }

    public object Resolve(CatalogItem source, CatalogItemDto destination, string sourceMember, object destMember,
        ResolutionContext context)
    {
        return $"{_config.Host}/{_config.ImgUrl}/{sourceMember}";
    }
}