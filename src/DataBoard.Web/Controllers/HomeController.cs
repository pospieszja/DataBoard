using Microsoft.AspNetCore.Mvc;

namespace DataBoard.Web.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}