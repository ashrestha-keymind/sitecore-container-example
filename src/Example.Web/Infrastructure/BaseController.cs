namespace Example.Web.Infrastructure
{
    using System.Web.Mvc;
    using MediatR;
    using Sitecore.DependencyInjection;

    public abstract class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = (IMediator)ServiceLocator.ServiceProvider.GetService(typeof(IMediator)));

        protected ActionResult ViewOrEmpty(object model)
        {
            return ViewOrEmpty(null, model);
        }

        protected ActionResult ViewOrEmpty(string viewName, object model)
        {
            if (model == null)
            {
                return new EmptyResult();
            }

            return View(viewName, null, model);
        }
    }
}
