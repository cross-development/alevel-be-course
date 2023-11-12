using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;
using Basket.Host.Models.Requests;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRouteV1)]
public class BasketItemController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketItemController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddItemRequest request)
    {
        if (request.Data == null)
        {
            return BadRequest("Could not add a provided data to the basket");
        }

        var userId = User.Claims.FirstOrDefault(claim => claim.Type == "sub")?.Value;

        var hasAdded = await _basketService.AddItemAsync(userId, request.Data);

        return CreatedAtAction(nameof(Add), hasAdded);
    }
}
