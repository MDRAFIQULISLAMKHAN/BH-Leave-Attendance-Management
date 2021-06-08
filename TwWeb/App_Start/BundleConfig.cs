using System.Web;
using System.Web.Optimization;

namespace TwWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/jquery-single").Include(
                "~/Scripts/ThirdPartyJs/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/easing").Include(
                "~/Scripts/ThirdPartyJs/jquery.easing.1.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/bootstrap").Include(
                "~/Scripts/ThirdPartyJs/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/modernizrcustom").Include(
                "~/Scripts/ThirdPartyJs/modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/toucheffects").Include(
                "~/Scripts/ThirdPartyJs/toucheffects.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/google-code-prettify").Include(
                "~/Scripts/ThirdPartyJs/google-code-prettify/prettify.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/bxslider").Include(
                "~/Scripts/ThirdPartyJs/jquery.bxslider.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/camera").Include(
                "~/Scripts/ThirdPartyJs/camera/camera.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/camera-setting").Include(
                "~/Scripts/ThirdPartyJs/camera/setting.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/prettyPhoto").Include(
                "~/Scripts/ThirdPartyJs/jquery.prettyPhoto.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/portfolio").Include(
                "~/Scripts/ThirdPartyJs/portfolio/jquery.quicksand.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/portfolio-setting").Include(
                "~/Scripts/ThirdPartyJs/portfolio/setting.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/flexslider").Include(
                "~/Scripts/ThirdPartyJs/jquery.flexslider.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/animate").Include(
                "~/Scripts/ThirdPartyJs/animate.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/inview").Include(
                "~/Scripts/ThirdPartyJs/inview.js"));

            bundles.Add(new ScriptBundle("~/bundles/CustomJs/customJs").Include(
                "~/Scripts/CustomJs/custom.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/clientslider").Include(
                "~/Scripts/ThirdPartyJs/client-slider.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/slick").Include(
                "~/Scripts/ThirdPartyJs/slick.min.js"));





            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/jquery").Include(
                        "~/Scripts/ThirdPartyJs/jquery-1.9.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/jqueryval").Include(
                        "~/Scripts/ThirdPartyJs/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/jqueryvalUnobtrusive").Include(
                "~/Scripts/ThirdPartyJs/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/modernizr").Include(
                        "~/Scripts/ThirdPartyJs/modernizr-2.8.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/bootstrap").Include(
                      "~/Scripts/ThirdPartyJs/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdPartyJs/cslider").Include(
                "~/Scripts/ThirdPartyJs/jquery.cslider.js"));



            // CSS
            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/bootstrapcss").Include(
                "~/Content/ThirdPartyCss/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/bootstrap-responsive").Include(
                "~/Content/ThirdPartyCss/bootstrap-responsive.css"));

            //Old
            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/flexslider").Include(
                "~/Content/ThirdPartyCss/flexslider.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/prettyPhoto").Include(
                "~/Content/ThirdPartyCss/prettyPhoto.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/camera").Include(
                "~/Content/ThirdPartyCss/camera.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/bxslider").Include(
                "~/Content/ThirdPartyCss/jquery.bxslider.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/slick").Include(
                "~/Content/ThirdPartyCss/slick.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/slick-theme").Include(
                "~/Content/ThirdPartyCss/slick-theme.css"));

            bundles.Add(new StyleBundle("~/Content/CustomCss/style").Include(
                "~/Content/CustomCss/style.css"));
            
            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/defaultColor").Include(
                "~/Content/ThirdPartyCss/default.css"));


            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/css").Include(
                      "~/Content/ThirdPartyCss/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/bootstrap-responsive").Include(
                      "~/Content/ThirdPartyCss/bootstrap-responsive.min.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/animate").Include(
                "~/Content/ThirdPartyCss/animate.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/font-awesome").Include(
                "~/Content/ThirdPartyCss/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/cslider").Include(
                "~/Content/ThirdPartyCss/cslider.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/overwrite").Include(
                "~/Content/ThirdPartyCss/overwrite.css"));

            bundles.Add(new StyleBundle("~/Content/ThirdPartyCss/shortcodes").Include(
                "~/Content/ThirdPartyCss/shortcodes.css"));




        }
    }
}
