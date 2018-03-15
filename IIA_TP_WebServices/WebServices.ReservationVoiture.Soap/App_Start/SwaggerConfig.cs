using System.Web.Http;
using WebActivatorEx;
using WebServices.ReservationVoiture.Soap;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebServices.ReservationVoiture.Soap
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebServices.ReservationVoiture.Soap");
})
                .EnableSwaggerUi();
        }
    }
}
