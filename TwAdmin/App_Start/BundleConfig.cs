using System.Web;
using System.Web.Optimization;

namespace TwAdmin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvalUnobtrusive").Include(
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/buttons-html5").Include(
                "~/Scripts/buttons.html5.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/buttons-print").Include(
                "~/Scripts/buttons.print.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables-buttons").Include(
                "~/Scripts/dataTables.buttons.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dropzone").Include(
                "~/Scripts/dropzone.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/flatpickr").Include(
                "~/Scripts/flatpickr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-scrollLock").Include(
                "~/Scripts/jquery-scrollLock.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                "~/Scripts/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollbar").Include(
                "~/Scripts/jquery.scrollbar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/lightgallery").Include(
                "~/Scripts/lightgallery-all.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                "~/Scripts/select2.full.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert2").Include(
                "~/Scripts/sweetalert2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/trumbowyg").Include(
                "~/Scripts/trumbowyg.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appMin").Include(
                "~/Scripts/CustomJs/app.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/demo").Include(
                "~/Scripts/CustomJs/demo.js"));




            // CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/VendorCss/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/dropzone").Include(
                      "~/Content/VendorCss/dropzone.css"));

            bundles.Add(new StyleBundle("~/Content/animate").Include(
                "~/Content/VendorCss/animate.min.css"));

            bundles.Add(new StyleBundle("~/Content/flatpickr").Include(
                "~/Content/VendorCss/flatpickr.min.css"));

            bundles.Add(new StyleBundle("~/Content/scrollbar").Include(
                "~/Content/VendorCss/jquery.scrollbar.css"));

            bundles.Add(new StyleBundle("~/Content/lightgallery").Include(
                "~/Content/VendorCss/lightgallery.min.css"));

            bundles.Add(new StyleBundle("~/Content/iconic-font").Include(
                "~/Content/VendorCss/material-design-iconic-font.min.css"));

            bundles.Add(new StyleBundle("~/Content/select2").Include(
                "~/Content/VendorCss/select2.min.css"));

            bundles.Add(new StyleBundle("~/Content/sweetalert2").Include(
                "~/Content/VendorCss/sweetalert2.min.css"));

            bundles.Add(new StyleBundle("~/Content/trumbowyg").Include(
                "~/Content/VendorCss/trumbowyg.min.css"));

            bundles.Add(new StyleBundle("~/Content/appMin").Include(
                "~/Content/CustomCss/app.min.css"));

            bundles.Add(new StyleBundle("~/Content/demo").Include(
                "~/Content/CustomCss/demo.css"));
        }
    }
}
