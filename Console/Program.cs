using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbrellaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "伞租赁服务控制台 Ver1.0--Powered by Diablo";

                string serverAddr = ConfigurationManager.AppSettings["server"];
                using (WebApp.Start<Startup>(serverAddr))
                {
                    Console.WriteLine("伞租赁服务已启动，启动时间：{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    Console.WriteLine("按回车键退出...");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
