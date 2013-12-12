using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace JotAThought.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.validate.js"
                ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/bootstrap/bootstrap.min.css",
                "~/Content/Custom.css"
                ));
        }
    }
}