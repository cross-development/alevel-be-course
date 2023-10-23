using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using HW_6_2.Helpers;
using HW_6_2.Models.Requests;
using HW_6_2.Models.Responses;
using HW_6_2.Services.Interfaces;

namespace HW_6_2.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRouteV1)]
public sealed class CatalogTypeController : ControllerBase
{
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(ICatalogTypeService catalogTypeService)
    {
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AddItemResponse<int?>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] AddTypeRequest request)
    {
        var result = await _catalogTypeService.AddCatalogTypeAsync(request);

        return Created(nameof(Add), new AddItemResponse<int?> { Id = result });
    }

    [HttpDelete("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var item = await _catalogTypeService.GetCatalogTypeByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        var result = await _catalogTypeService.DeleteCatalogTypeAsync(item);

        if (!result)
        {
            return BadRequest("Could not delete the catalog type");
        }

        return NoContent();
    }
}
