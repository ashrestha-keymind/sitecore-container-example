namespace Example.Web.Features.Card
{
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Web.Features.Shared.Model;
    using MediatR;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;

    public class CardQuery : IRequest<CardViewModel>
    {
    }

    public class CardQueryHandler : IRequestHandler<CardQuery, CardViewModel>
    {
        public Task<CardViewModel> Handle(CardQuery request, CancellationToken cancellationToken)
        {
            var renderingItem = RenderingContext.Current.Rendering.Item;

            var model = new CardViewModel
            {
                Description = renderingItem["Description"],
                Image = GetMediaUrl(renderingItem.Fields["Image"])
            };

            return Task.FromResult(model);
        }

        private ImageViewModel GetMediaUrl(ImageField field) 
        {
            var result = new ImageViewModel();

            if (field != null && field.MediaItem != null)
            {
                var image = new MediaItem(field.MediaItem);
                var src = Sitecore.StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(image));

                result.Url = src;
                result.AltText = image.Alt;
            }

            return result;
        }
    }
}
