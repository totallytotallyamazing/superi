using System.Web.Mvc;

namespace Shop.Areas.BrandCatalog
{
    public class BrandCatalogAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BrandCatalog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BrandCatalog_default",
                "BrandCatalog/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
