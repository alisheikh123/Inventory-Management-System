using System.Web;
using System.Web.Optimization;

namespace Inventory_Management_Systems
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/admin-lte/js")
             .Include("~/admin-lte/plugins/fastclick/fastclick.js"
             
             ));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                       .Include("~/Scripts/jquery-{version}.js")
                       .Include("~/admin-lte/bower_components/select2/dist/js/select2.min.js")
                       .Include("~/Content/plugins/DataTables-1.10.20/datatables.min.js")
                       .Include("~/Content/Magicsuggest-magicsuggest-cf74869/magicsuggest.js")




                       );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.validate*")
                        .Include("~/Scripts/jquery.validate.unobtrusive.js")
                        
                        
                   
                       
                     
                        );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                      

                        ));
                                        
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js")
                    //.Include("~/Content/plugins/bootstrap/jsbootstrap.bundle.js")
                    //  .Include("~/Scripts/AdminLTE/bootstrap/js/bootstrap.bundle.js")
                      


                      );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css")
                      .Include("~/admin-lte/bower_components/select2/dist/css/select2.min.css")
                       .Include("~/admin-lte/css/AdminLTE.css")
                      .Include("~/admin-lte/css/skins/skin-blue.css")
                      .Include("~/Content/plugins/DataTables-1.10.20/datatables.min.css")
                      .Include("~/Content/Magicsuggest-magicsuggest-cf74869/magicsuggest.css")

                       );
        }
    }
}
