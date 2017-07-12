using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Database.DAL;
using Umbrella.Database.IBLL;
using Umbrella.Database.IDAL;

namespace Umbrella.Database.BLL
{
    public abstract class BaseBLL<T, U> : IBaseBLL<T>
        where T : class
        where U : IBaseDAL<T>
    {
        protected U baseDAL { get; set; }

        private static readonly object syncRoot = new Object();
        IUnityContainer container { get; set; }

        public BaseBLL()
        {
            lock (syncRoot)
            {
                container = DALFactory.Instance.Container;
                if (container == null)
                {
                    throw new ArgumentNullException("container", "container没有初始化");
                }
            }

            baseDAL = container.Resolve<U>();
        }

        public bool Insert(T t)
        {
            return baseDAL.Insert(t);
        }

        public bool Delete(T t)
        {
            return baseDAL.Delete(t);
        }

        public bool Delete(object id)
        {
            return baseDAL.Delete(id);
        }

        public bool Update(T t, object key)
        {
            return baseDAL.Update(t, key);
        }

        public IList<T> FindAll()
        {
            return baseDAL.FindAll();
        }

        public T FindByID(object id)
        {
            return baseDAL.FindByID(id);
        }
    }
}
