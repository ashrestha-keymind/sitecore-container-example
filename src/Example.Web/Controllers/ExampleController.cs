using System.Web.Mvc;

namespace Example.Web.Controllers
{
    public class ExampleController : Controller
    {
        public ActionResult ExampleControllerRendering()
        {
            return View();
        }
    }
}