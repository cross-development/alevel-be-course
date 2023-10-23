using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using HW_6_2.Helpers;
using HW_6_2.Models.DTOs;
using HW_6_2.Models.Requests;
using HW_6_2.Models.Responses;
using HW_6_2.Services.Interfaces;

namespace HW_6_2.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRouteV1)]
public sealed class CatalogBffController : ControllerBase
{
    private readonly ICatalogItemService _catalogItemService;
    private readonly ICatalogBrandService _catalogBrandService;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogBffController(
        ICatalogItemService catalogItemService,
        ICatalogBrandService catalogBrandService,
        ICatalogTypeService catalogTypeService)
    {
        _catalogItemService = catalogItemService;
        _catalogBrandService = catalogBrandService;
        _catalogTypeService = catalogTypeService;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(PaginatedResponse<CatalogItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Items([FromQuery] PaginatedFilterRequest request)
    {
        var result = await _catalogItemService.GetCatalogItemsAsync(request);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(CatalogItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Item([FromRoute] int id)
    {
        var result = await _catalogItemService.GetCatalogItemByIdAsync(id);

        return Ok(result);
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(PaginatedResponse<CatalogBrandDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Brands([FromQuery] PaginatedRequest request)
    {
        var result = await _catalogBrandService.GetCatalogBrandsAsync(request);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(CatalogBrandDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Brand([FromRoute] int id)
    {
        var result = await _catalogBrandService.GetCatalogBrandByIdAsync(id);

        return Ok(result);
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(PaginatedResponse<CatalogTypeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Types([FromQuery] PaginatedRequest request)
    {
        var result = await _catalogTypeService.GetCatalogTypesAsync(request);

        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(CatalogTypeDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Type([FromRoute] int id)
    {
        var result = await _catalogTypeService.GetCatalogTypeByIdAsync(id);

        return Ok(result);
    }
}
