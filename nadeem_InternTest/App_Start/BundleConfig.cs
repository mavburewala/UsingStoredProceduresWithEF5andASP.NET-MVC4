using System.Web;
using System.Web.Optimization;

namespace nadeem_InternTest
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/carousel").Include(
                        "~/Scripts/carousel.js",
                        "~/Scripts/holder.js"));


            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));
            


            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/css/bootstrap.css",
                        "~/Content/css/bootstrap-theme.css"));
            bundles.Add(new StyleBundle("~/Content/carousel").Include(
                        "~/Content/css/carousel.css"));
            
        }
    }
}