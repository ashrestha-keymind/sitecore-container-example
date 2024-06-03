namespace Example.Web.Infrastructure.Services
{
    using Example.Web.Features.Shared.Model;
    using Example.Web.Infrastructure.Services.Interfaces;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Resources.Media;

    public class MediaService : IMediaService
    {
        public ImageViewModel GetImage(ImageField field)
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
