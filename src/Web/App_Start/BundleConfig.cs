using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/scripts/jquery/jquery-1.11.1.js",
                "~/scripts/bootstrap/bootstrap.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/scripts/require.js",
                "~/scripts/jquery/jquery-1.10.2.js",
                "~/scripts/angular/angular.js",
                "~/scripts/angular/angular-ui.js",
                "~/scripts/angular/angular-ui-router.js",
                "~/scripts/bootstrap/ui-bootstrap-tpls-0.11.0.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/rest").Include(
                "~/scripts/plugins/underscore/underscore.js",
                "~/scripts/plugins/select2/select.js"
            ));
            
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/scripts/app/app.js",
                "~/scripts/app/helpers/ui-helpers.js",
				"~/scripts/app/services/project-service.js",
				"~/scripts/app/services/issue-service.js",
				"~/scripts/app/controllers/new-project-controller.js",
				"~/scripts/app/controllers/new-issue-controller.js",
				"~/scripts/app/controllers/dashboard-controller.js",
				"~/scripts/app/controllers/project-controller.js",
				"~/scripts/app/controllers/issues-controller.js"
            )); 

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/markdown/angular-pagedown.css",
                      "~/Content/select2/select.css",
                      "~/Content/select2/select2.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/logincss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/signin.css"
                      ));


            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            //BundleTable.EnableOptimizations = true;
        }
    }
}
