using System.Web;
using System.Web.Mvc;

namespace Game_Arena
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           
              //disables access on http
        }
    }
}
