using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using HW_6_3.Host.Helpers;
using HW_6_3.Host.Models.Requests;
using HW_6_3.Host.Models.Responses;
using HW_6_3.Host.Services.Interfaces;

namespace HW_6_3.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRouteV1)]
public sealed class CatalogBrandController : ControllerBase
{
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(ICatalogBrandService catalogBrandService)
    {
        _catalogBrandService = catalogBrandService;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AddItemResponse<int?>), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddBrandRequest request)
    {
        var result = await _catalogBrandService.AddCatalogBrandAsync(request);

        if (result == null)
        {
            return BadRequest("Could not add the catalog brand");
        }

        return CreatedAtAction(nameof(Add), new AddItemResponse<int?> { Id = result });
    }

    [HttpPatch("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AddItemResponse<int?>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBrandRequest request)
    {
        var item = await _catalogBrandService.FindCatalogBrandAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        var result = await _catalogBrandService.UpdateCatalogBrandAsync(request, item);

        if (result == null)
        {
            return BadRequest("Could not update the catalog brand");
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
        var item = await _catalogBrandService.FindCatalogBrandAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        var result = await _catalogBrandService.DeleteCatalogBrandAsync(item);

        if (!result)
        {
            return BadRequest("Could not delete the catalog brand");
        }

        return NoContent();
    }
}
