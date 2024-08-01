namespace Example.Web.Features.Banner.OneColumn
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Web.Features.Shared.Model;
    using MediatR;
    using Sitecore.Mvc.Presentation;

    public class OneColumnQuery : IRequest<OneColumnViewModel>
    {
    }

    public class OneColumnQueryHandler : IRequestHandler<OneColumnQuery, OneColumnViewModel>
    {
        public Task<OneColumnViewModel> Handle(OneColumnQuery request, CancellationToken cancellationToken)
        {
            var renderingItem = RenderingContext.Current.Rendering.Item;

            var model = new OneColumnViewModel
            {
                Title = renderingItem["Title"],
                Description = renderingItem["Description"],
                Links = renderingItem.GetChildren()
                .Where(x => x.TemplateName == "Banner")
                .Select(x => new LinkViewModel
                {
                    Label = x["Label"],
                    Href = x["Href"]
                })
            };

            return Task.FromResult(model);
        }
    }
}
