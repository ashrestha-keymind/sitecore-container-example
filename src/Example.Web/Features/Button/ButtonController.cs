namespace Example.Web.Features.Button
{
    using System.Web.Mvc;
    using Example.Web.Infrastructure;

    public class ButtonController : BaseController
    {
        public ActionResult ButtonComponent()
        {
            var model = Mediator.Send(new ButtonQuery()).GetAwaiter().GetResult();
            return View(model);
        }
    }
}
