namespace Example.Web.Features.Header
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Sitecore.Mvc.Extensions;
    using Sitecore.Mvc.Presentation;

    public class HeaderComponentQuery : IRequest<HeaderViewModel>
    {
    }

    public class HeaderQueryHandler : IRequestHandler<HeaderComponentQuery, HeaderViewModel>
    {
        public Task<HeaderViewModel> Handle(HeaderComponentQuery request, CancellationToken cancellationToken)
        {
            // Get the current rendering item
            var currentRendering = RenderingContext.Current.Rendering.Item;
            if (currentRendering == null)
            {
                return Task.FromResult<HeaderViewModel>(null);
            }

            var model = new HeaderViewModel
            {
                Title = currentRendering["Title"].OrIfEmpty("Default Site Title")
            };
            
            return Task.FromResult(model);
        }
    }
}
