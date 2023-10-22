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
    private readonly ICatalogService _catalogService;

    public CatalogBffController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(PaginatedResponse<CatalogItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Items([FromQuery] PaginatedRequest query)
    {
        var result = await _catalogService.GetCatalogItemsAsync(query.PageIndex, query.PageSize);

        return Ok(result);
    }
}
