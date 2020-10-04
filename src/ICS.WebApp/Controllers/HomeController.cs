using System.Web.Mvc;

namespace ICS.WebApp.Controllers
{
    [AllowAnonymous]
    public sealed class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Page()
        {
            return View();
        }
    }
}