namespace Example.Web.Features.TitleSummary
{
    using System.Web.Mvc;
    using Example.Web.Infrastructure;

    public class TitleSummaryController : BaseController
    {
        public ActionResult TitleSummaryComponent()
        {
            var model = Mediator.Send(new TitleSummaryQuery()).GetAwaiter().GetResult();
            return View(model);
        }
    }
}
