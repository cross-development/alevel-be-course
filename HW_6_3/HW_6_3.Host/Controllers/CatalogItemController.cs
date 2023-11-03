using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using HW_6_3.Host.Helpers;
using HW_6_3.Host.Models.Requests;
using HW_6_3.Host.Models.Responses;
using HW_6_3.Host.Services.Interfaces;

namespace HW_6_3.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRouteV1)]
public sealed class CatalogItemController : ControllerBase
{
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(ICatalogItemService catalogItemService)
    {
        _catalogItemService = catalogItemService;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AddItemResponse<int?>), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddItemRequest request)
    {
        var result = await _catalogItemService.AddCatalogItemAsync(request);

        if (result == null)
        {
            return BadRequest("Could not add the catalog item");
        }

        return CreatedAtAction(nameof(Add), new AddItemResponse<int?> { Id = result });
    }

    [HttpPatch("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AddItemResponse<int?>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateItemRequest request)
    {
        var item = await _catalogItemService.FindCatalogItemAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        var result = await _catalogItemService.UpdateCatalogItemAsync(request, item);

        if (result == null)
        {
            return BadRequest("Could not update the catalog type");
        }

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var item = await _catalogItemService.FindCatalogItemAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        var result = await _catalogItemService.DeleteCatalogItemAsync(item);

        if (!result)
        {
            return BadRequest("Could not delete the catalog item");
        }

        return NoContent();
    }
}
