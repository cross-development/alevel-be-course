﻿using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using EShop.Configurations;
using EShop.DTOs.Requests;
using EShop.DTOs.Responses;
using EShop.Services.Interfaces;

namespace EShop.Services;

public sealed class CatalogService : ICatalogService
{
    private readonly IHttpClientService _httpClientService;
    private readonly ApiConfiguration _apiOptions;

    public CatalogService(IHttpClientService httpClientService, IOptions<ApiConfiguration> apiOptions)
    {
        _httpClientService = httpClientService;
        _apiOptions = apiOptions.Value;
    }

    public async Task<CatalogResponseDto> GetCatalogItems(CatalogRequestDto catalogRequest)
    {
        var result = await _httpClientService.SendAsync<CatalogResponseDto, CatalogRequestDto>(
            $"{_apiOptions.CatalogUrl}/items",
            HttpMethod.Get,
            catalogRequest);

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetBrands()
    {
        var result = await _httpClientService.SendAsync<BrandResponseDto>(
            $"{_apiOptions.CatalogUrl}/brands",
            HttpMethod.Get);

        var listOfBrands = result.Data
            .Select(catalogBrand => new SelectListItem { Value = $"{catalogBrand.Id}", Text = catalogBrand.Brand })
            .ToList();

        return listOfBrands;
    }

    public async Task<IEnumerable<SelectListItem>> GetTypes()
    {
        var result = await _httpClientService.SendAsync<TypeResponseDto>(
            $"{_apiOptions.CatalogUrl}/types",
            HttpMethod.Get);

        var listOfTypes = result.Data
            .Select(catalogType => new SelectListItem { Value = $"{catalogType.Id}", Text = catalogType.Type })
            .ToList();

        return listOfTypes;
    }
}