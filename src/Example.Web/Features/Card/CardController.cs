namespace Example.Web.Features.Card
{
    using System.Web.Mvc;
    using Example.Web.Infrastructure;

    public class CardController : BaseController
    {
        public ActionResult CardComponent()
        {
            var model = Mediator.Send(new CardQuery()).GetAwaiter().GetResult();
            return ViewOrEmpty(model);
        }
    }
}
