namespace Example.Web.Features.ExampleComponent
{
    using System.Web.Mvc;
    using Example.Web.Infrastructure;

    public class ExampleComponentController : BaseController
    {
        public ActionResult Component()
        {
            var model = Mediator.Send(new ExampleComponentQuery()).GetAwaiter().GetResult();
            return View(model);
        }
    }
}
