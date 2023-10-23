using AutoMapper;
using HW_6_2.Models.DTOs;
using HW_6_2.Data.Entities;

namespace HW_6_2.Mapping;

public class CatalogItemFileResolver : IMemberValueResolver<CatalogItemDto, CatalogItem, string, object>
{
    public object Resolve(CatalogItemDto source, CatalogItem destination, string sourceMember, object destMember,
        ResolutionContext context)
    {
        var pictureFileName = sourceMember?.Split("/")?[2];

        return pictureFileName;
    }
}