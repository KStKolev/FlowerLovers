using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult UserPage() 
        {
            return View();
        }
    }
}
