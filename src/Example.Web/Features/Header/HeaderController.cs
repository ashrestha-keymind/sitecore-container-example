namespace Example.Web.Features.Header
{
    using System.Web.Mvc;
    using Example.Web.Infrastructure;

    public class HeaderController : BaseController
    {
        public ActionResult HeaderComponent()
        {
            var model = Mediator.Send(new HeaderComponentQuery()).GetAwaiter().GetResult();
            return ViewOrEmpty(model);
        }
    }
}
