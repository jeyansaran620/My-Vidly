using System.Web;
using System.Web.Mvc;

namespace My_Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
