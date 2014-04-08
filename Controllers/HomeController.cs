using System.Web.Mvc;

namespace BowlingScore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ViewModels.Home.IndexViewModel());
        }
    }
}
