using System.Web;
using System.Web.Mvc;
using TelerikTestDateinGrid.Helpers;

namespace TelerikTestDateinGrid
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Get client timezone from cookies that its leaving
            filters.Add(new ClientTimeZoneAttribute());

        }
    }
}
