using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("Error404");
                case 500:
                    return View("Error500");

                // Handle other error codes as needed
                default:
                    return View("Error");
            }
        }
    }
}
