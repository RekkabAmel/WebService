
using System.Web.Optimization;

namespace AJSWebapi
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js"
                        , "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/controller").Include(
                        "~/Scripts/MyScripts/Controller.js"));
            bundles.Add(new ScriptBundle("~/bundles/module").Include(
                        "~/Scripts/MyScripts/Module.js"));
            bundles.Add(new ScriptBundle("~/bundles/service").Include(
                        "~/Scripts/MyScripts/service.js"));

            bundles.Add(new StyleBundle("~/Content/css/Home").Include(
                      "~/Content/home.css"));

        }
    }
}