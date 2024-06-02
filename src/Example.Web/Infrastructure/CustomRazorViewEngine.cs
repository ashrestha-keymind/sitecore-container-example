namespace Example.Web.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class CustomRazorViewEngine : RazorViewEngine
    {
        public CustomRazorViewEngine()
        {
            // Get the default view formats
            var masterLocationFormats = MasterLocationFormats.ToList();
            var partialViewLocationFormats = PartialViewLocationFormats.ToList();
            var viewLocationFormats = ViewLocationFormats.ToList();

            // View format for Feature structure
            var featureLocationFormats = new List<string>
            {
                "~/Features/{1}/{0}.cshtml",
                "~/Features/Shared/Views/{0}.cshtml"
            };

            masterLocationFormats.AddRange(featureLocationFormats);
            partialViewLocationFormats.AddRange(featureLocationFormats);
            viewLocationFormats.AddRange(featureLocationFormats);

            // Add the feature structure to the format list
            MasterLocationFormats = masterLocationFormats.ToArray();
            PartialViewLocationFormats = partialViewLocationFormats.ToArray();
            ViewLocationFormats = viewLocationFormats.ToArray();
        }
    }
}
