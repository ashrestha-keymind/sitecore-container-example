namespace Example.Web.Features.Jumbotron
{
    using System.Web.Mvc;
    using Example.Web.Infrastructure;

    public class JumbotronController : BaseController
    {
        public ActionResult JumbotronComponent()
        {
            var model = Mediator.Send(new JumbotronQuery()).GetAwaiter().GetResult();
            return ViewOrEmpty(model);
        }
    }
}
