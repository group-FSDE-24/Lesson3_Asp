using Microsoft.AspNetCore.Mvc;

namespace Lesson3_ASP_Net6.Controllers;

public class AydinController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
