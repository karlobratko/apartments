using System.Web.Optimization;

namespace Apartments.WebUI.App_Start {
  public class BundleConfig {
    public static void RegisterBundles(BundleCollection bundles) {
      bundles.Add(new StyleBundle("~/Content/bs").Include("~/Content/bootstrap.css"));
      bundles.Add(new StyleBundle("~/Content/es").Include("~/Content/ErrorStyles.css"));
      bundles.Add(new StyleBundle("~/Content/jqui").Include("~/Content/jquery-ui.css"));

      bundles.Add(new ScriptBundle("~/Scripts/bs").Include("~/Scripts/bootstrap.js"));
      bundles.Add(new ScriptBundle("~/Scripts/jq").Include("~/Scripts/jquery-{version}.js"));
      bundles.Add(new ScriptBundle("~/Scripts/jqui").Include("~/Scripts/jquery-ui.js"));
      bundles.Add(new ScriptBundle("~/Scripts/jqval").Include("~/Scripts/jquery.validate.js",
                                                              "~/Scripts/jquery.validate.unobtrusive.js",
                                                              "~/Scripts/jquery.unobtrusive-ajax.js"));
    }
  }
}