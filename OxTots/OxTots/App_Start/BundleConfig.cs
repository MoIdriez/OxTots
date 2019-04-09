using System.Web;
using System.Web.Optimization;

namespace OxTots
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/plugins.js",
                        "~/Scripts/imagesloaded.pkgd.min.js",
                        "~/Scripts/isotope.pkgd.min.js",
                        "~/Scripts/slick.min.js",
                        "~/Scripts/parallaxie.js",
                        "~/Scripts/select2.full.min.js",
                        "~/Scripts/jquery.datetimepicker.full.min.js",
                        "~/Scripts/main.js",
                        "~/Scripts/Site.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-3.6.0.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/normalize.css",
                      "~/Content/main.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.min.css",
                      "~/Content/fontawesome-all.min.css",
                      "~/fonts/flaticon.css",
                      "~/fonts/select2.min.css",
                      "~/fonts/jquery.datetimepicker.css",
                      "~/Content/slick.css",
                      "~/Content/slick-theme.css",
                      "~/Content/style.css",
                      "~/Content/Site.css"));
        }
    }
}
