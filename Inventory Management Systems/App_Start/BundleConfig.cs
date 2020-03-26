using System.Web;
using System.Web.Optimization;

namespace Inventory_Management_Systems
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                         "~/admin-lte/js/app.js")
                         .Include("~/admin-lte/plugins/fastclick/fastclick.js"
                         )
                         .Include("~/Scripts/AdminLTE_dist/js/adminlte.js")
                         );

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                       .Include("~/Scripts/jquery-{version}.js")
                        .Include("~/Scripts/jquery-3.4.1.min.js")
                        .Include("~/Content/plugins/jquery/jquery.min.js")
                        .Include("~/Content/Magicsuggest-magicsuggest-cf74869/magicsuggest-min.js")
                        .Include("~/Scripts/AdminLTE/jquery/jquery.js")
                        

                       );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.validate*")
                        .Include("~/Scripts/jquery.validate.unobtrusive.js")
                        .Include("~/Scripts/jquery-ui-1.12.1.min.js")
                        
                   
                       
                     
                        );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                      

                        ));
                                        
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js")
                      .Include("~/Content/plugins/datatables-bs4/css/dataTables.bootstrap4.css")
                      .Include("~/Scripts/AdminLTE/bootstrap/js/bootstrap.bundle.js")
                      


                      );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                              "~/Content/bootstrap.css")
                             .Include("~/Content/site.css")
                              .Include("~/admin-lte/css/AdminLTE.css")
                              .Include("~/admin-lte/css/skins/skin-blue.css")
                             .Include("~/Content/Magicsuggest-magicsuggest-cf74869/magicsuggest-min.css")
                             .Include("~/Content/plugins/fontawesome-free/css/all.css")
                             .Include("~/Content/AdminLTE/css/adminlte.css")



                              );
        }
    }
}
