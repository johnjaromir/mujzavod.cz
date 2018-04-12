using System.Web;
using System.Web.Optimization;

namespace MujZavod.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            


            

            //font awesome
            bundles.Add(new StyleBundle("~/Content/css-font-awesome").Include(
                "~/Content/font-awesome/css/font-awesome.min.css"));



            bundles.Add(new ScriptBundle("~/Scripts/MujZavod/js").Include(
                      "~/Scripts/app/*.js"));



            // public registration
            bundles.Add(new ScriptBundle("~/Scripts/MujZavod/Registration").Include(
                      "~/scripts/js/jquery.min.js",
                      "~/scripts/js/bootstrap.min.js",
                      "~/scripts/js/pixeladmin.min.js",
                      "~/Scripts/app/MujZavodModal.js",
                      "~/Scripts/app/MujZavodRegistration.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/MujZavod/Registration").Include(
               "~/content/css/bootstrap.min.css",
               "~/content/css/pixeladmin.min.css"
               ));



            /*
            // exports
            bundles.Add(new ScriptBundle("~/Scripts/MujZavod/Export").Include(
                      "https://cdn.datatables.net/buttons/1.5.1/js/dataTables.buttons.min.js",
                      "https://cdn.datatables.net/buttons/1.5.1/js/buttons.flash.min.js",
                      "https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js",
                      "https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/pdfmake.min.js",
                      "https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/vfs_fonts.js",
                       "https://cdn.datatables.net/buttons/1.5.1/js/buttons.html5.min.js",
                       "https://cdn.datatables.net/buttons/1.5.1/js/buttons.print.min.js"
                      ));
             */
        }
    }
}
