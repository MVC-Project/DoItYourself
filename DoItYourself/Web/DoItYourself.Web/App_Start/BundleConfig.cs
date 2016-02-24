namespace DoItYourself.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include(
                "~/Scripts/bootstrap.js",
                "~/Content/bootstrap-theme/js/sb-admin-2.js",
                "~/Content/bootstrap-theme/metisMenu/src/metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo")
                .Include("~/Scripts/kendo/kendo.all.min.js", "~/Scripts/kendo/kendo.aspnetmvc.min.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css", "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/css")
                .Include("~/Content/kendo/kendo.common-material.min.css", "~/Content/kendo/kendo.material.min.css"));

            bundles.Add(new StyleBundle("~/Content/libs").Include(
                      "~/Content/font-awesome/css/font-awesome.css",
                      "~/Content/bootstrap-theme/css/sb-admin-2.css",
                      "~/Content/bootstrap-theme/css/timeline.css",
                      "~/Content/bootstrap-theme/metisMenu/src/metisMenu.css"));
        }
    }
}
