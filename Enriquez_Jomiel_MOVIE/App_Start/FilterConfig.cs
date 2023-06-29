using System.Web;
using System.Web.Mvc;

namespace Enriquez_Jomiel_MOVIE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
