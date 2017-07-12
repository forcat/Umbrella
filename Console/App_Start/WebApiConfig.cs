using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace UmbrellaConsole
{
    public static class WebApiConfig
    {
        public static void Register(this IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // 仅启用不记名令牌
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            // 去掉xml格式，那么返回的数据只是用json格式
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var jsonFormatter = config.Formatters.JsonFormatter;
            // 启用缩进格式
            //jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            // 启用驼峰格式
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // 设置日期时间格式
            jsonFormatter.SerializerSettings.DateFormatString = string.Format("yyyy-MM-dd HH:mm:ss");

            app.UseWebApi(config);
        }
    }
}
