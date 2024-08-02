namespace Example.Web.Features.Banner
{
    using System.Web.Mvc;
    using Example.Web.Features.Banner.OneColumn;
    using Example.Web.Features.Banner.TwoColumn;
    using Example.Web.Infrastructure;

    public class BannerController : BaseController
    {
        public ActionResult OneColumnComponent()
        {
            var model = Mediator.Send(new OneColumnQuery()).GetAwaiter().GetResult();
            return View(model); 
        }

        public ActionResult TwoColumnComponent()
        {
            var model = Mediator.Send(new TwoColumnQuery()).GetAwaiter().GetResult();
            return View(model);
        }
    }
}
