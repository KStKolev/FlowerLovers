using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User?.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("MainPage", "Article");
            }

            return View();
        }
    }
}
