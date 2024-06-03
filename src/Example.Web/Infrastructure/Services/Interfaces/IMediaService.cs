namespace Example.Web.Infrastructure.Services.Interfaces
{
    using Example.Web.Features.Shared.Model;
    using Sitecore.Data.Fields;

    public interface IMediaService
    {
        ImageViewModel GetImage(ImageField field);
    }
}
