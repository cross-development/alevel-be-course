using AutoMapper;
using HW_4_5.Dto;
using HW_4_5.Models;

namespace HW_4_5.Helpers;

/// <summary>
/// Mapping profiles for auto mapper.
/// </summary>
public class MappingProfiles : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfiles"/> class.
    /// </summary>
    public MappingProfiles()
    {
        CreateMap<Pet, PetDto>();
        CreateMap<Pet, PetListDto>();
        CreateMap<PetDto, Pet>();

        CreateMap<Breed, BreedDto>();
        CreateMap<Breed, BreedListDto>();
        CreateMap<BreedDto, Breed>();

        CreateMap<Location, LocationDto>();
        CreateMap<Location, LocationListDto>();
        CreateMap<LocationDto, Location>();

        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryListDto>();
        CreateMap<CategoryDto, Category>();
    }
}