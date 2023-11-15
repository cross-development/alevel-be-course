using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EShop.ViewModels.ErrorViewModels;

namespace EShop.Controllers;

public class ErrorController : Controller
{
    [HttpGet]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
