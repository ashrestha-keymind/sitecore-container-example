namespace Example.Web.Features.CardCollection
{
    using System.Web.Mvc;
    using Example.Web.Infrastructure;

    public class CardCollectionController : BaseController
    {
        public ActionResult CardCollectionComponent()
        {
            var model = Mediator.Send(new CardCollectionQuery()).GetAwaiter().GetResult();
            return ViewOrEmpty(model);
        }
    }
}
