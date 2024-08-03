namespace Example.Web.Features.Button
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    public class ButtonQuery : IRequest<ButtonViewModel>
    {
        public Item RenderingItem => RenderingContext.Current.Rendering.Item;
    }

    public class ButtonQueryHandler : IRequestHandler<ButtonQuery, ButtonViewModel>
    {
        public Task<ButtonViewModel> Handle(ButtonQuery request, CancellationToken cancellationToken)
        {
            var model = new ButtonViewModel
            {
                Label = request.RenderingItem["Label"],
                Link = (LinkField)request.RenderingItem.Fields["Href"]
            };

            return Task.FromResult(model);
        }
    }
}
