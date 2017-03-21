using System.Web.Http;
using WebActivatorEx;
using DeusVultOnline;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DeusVultOnline
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "DeusVultOnline");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
