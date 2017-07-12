using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbrellaConsole
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 配置路由
            app.Register();

            // 启用欢迎页
            //app.UseWelcomePage("/");

            app.UseErrorPage();
        }
    }
}
