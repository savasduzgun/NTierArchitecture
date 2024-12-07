using Microsoft.AspNetCore.Mvc;

namespace NTierArchitecture.WebApi.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
