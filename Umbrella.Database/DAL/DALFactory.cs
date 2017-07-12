using Microsoft.Practices.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Database.DAL
{
    public class DALFactory
    {
        //普通局部变量
        private static Hashtable objCache = new Hashtable();
        private static object syncRoot = new Object();
        private static DALFactory myInstance = null;

        /// <summary>
        /// IOC的容器，可调用来获取对应接口实例。
        /// </summary>
        public IUnityContainer Container { get; set; }


        /// <summary>
        /// 创建或者从缓存中获取对应业务类的实例
        /// </summary>
        public static DALFactory Instance
        {
            get
            {
                if (myInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (myInstance == null)
                        {
                            myInstance = new DALFactory();
                            //初始化相关的注册接口
                            myInstance.Container = new UnityContainer();
                            //根据约定规则自动注册DAL
                            RegisterDAL(myInstance.Container);
                            //手工加载
                            //myInstance.Container.RegisterType<ICityDAL, CityDAL>();
                        }
                    }
                }
                return myInstance;
            }
        }

        /// <summary>
        /// 使用Unity自动加载对应的IDAL接口的实现（DAL层）
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterDAL(IUnityContainer container)
        {
            Dictionary<string, Type> dictInterface = new Dictionary<string, Type>();
            Dictionary<string, Type> dictDAL = new Dictionary<string, Type>();
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string dalSuffix = ".DAL";
            string interfaceSuffix = ".IDAL";
            foreach (Type objType in currentAssembly.GetTypes())
            {
                string defaultNamespace = objType.Namespace;

                if (!string.IsNullOrEmpty(defaultNamespace))
                {
                    if (objType.IsInterface && defaultNamespace.EndsWith(interfaceSuffix))
                    {
                        if (!dictInterface.ContainsKey(objType.FullName))
                        {
                            dictInterface.Add(objType.FullName, objType);
                        }
                    }
                    else if (defaultNamespace.EndsWith(dalSuffix))
                    {
                        if (!dictDAL.ContainsKey(objType.FullName))
                        {
                            dictDAL.Add(objType.FullName, objType);
                        }
                    }
                }
            }
            //根据注册的接口和接口实现集合，使用IOC容器进行注册
            foreach (string key in dictInterface.Keys)
            {
                Type interfaceType = dictInterface[key];
                foreach (string dalKey in dictDAL.Keys)
                {
                    Type dalType = dictDAL[dalKey];
                    if (interfaceType.IsAssignableFrom(dalType))//判断DAL是否实现了某接口
                    {
                        container.RegisterType(interfaceType, dalType);
                    }
                }
            }
        }
    }
}
