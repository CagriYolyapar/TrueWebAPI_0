using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;


namespace TrueWebAPI_0
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Alt taraftaki EnableCorsAttribute constructor argümanlarından ilkinin yıldız olması tüm farklı projelerin bu API'ya baglanmasına izin verildigini bildirir ("www.cihan.com,www.cagri.com"),ikinci argüman Headers yani bir HttpContext icerisinde tasınan bilgi baslıkları icerisinden hangi baslıkların request'te gelmesine izin veriliyor onu bildirir , 3.sü methods siz hangi metotları dısarı acmak istiyorsunuz bunu belirtir...
            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");

            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
