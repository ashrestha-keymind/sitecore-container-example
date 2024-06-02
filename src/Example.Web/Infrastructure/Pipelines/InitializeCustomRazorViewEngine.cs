namespace Example.Web.Infrastructure.Pipelines
{
    using System.Web.Mvc;
    using Sitecore.Pipelines;

    public class InitializeCustomRazorViewEngine
    {
        public void Process(PipelineArgs args)
        {
            Sitecore.Diagnostics.Log.Info("Register custom Razor view engine", this);
            ViewEngines.Engines.Insert(0, new CustomRazorViewEngine());
        }
    }
}
