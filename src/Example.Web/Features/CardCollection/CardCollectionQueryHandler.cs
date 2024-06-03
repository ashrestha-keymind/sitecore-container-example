namespace Example.Web.Features.CardCollection
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Web.Features.Shared.Model;
    using MediatR;
    using Sitecore.Common;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;

    public class CardCollectionQuery : IRequest<CardCollectionViewModel>
    {
    }

    public class CardCollectionQueryHandler : IRequestHandler<CardCollectionQuery, CardCollectionViewModel>
    {
        public Task<CardCollectionViewModel> Handle(CardCollectionQuery request, CancellationToken cancellationToken)
        {
            var renderingItem = RenderingContext.Current.Rendering.Item;
            var model = new CardCollectionViewModel();

            var cards = renderingItem.Children.Where(x => x.TemplateName == "Card").WhereNotNull();

            foreach (var cardItem in cards)
            {
                var card = new CardViewModel
                {
                    Description = cardItem["Description"],
                    Image = GetMediaUrl(cardItem.Fields["Image"])
                };

                model.Cards.Add(card);
            }

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
