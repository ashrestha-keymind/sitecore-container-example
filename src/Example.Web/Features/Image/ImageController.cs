namespace Example.Web.Features.Image
{
    using System.Web.Mvc;
    using Example.Web.Infrastructure;

    public class ImageController : BaseController
    {
        public ActionResult ImageComponent()
        {
            var model = Mediator.Send(new ImageQuery()).GetAwaiter().GetResult();
            return View(model);
        }
    }
}
