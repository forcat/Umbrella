using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Database.IDAL;

namespace Umbrella.Database.DAL
{
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : class
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private DbEntities dbContext = new DbEntities();

        public bool Insert(T t)
        {
            dbContext.Set<T>().Add(t);
            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(object id)
        {
            T obj = dbContext.Set<T>().Find(id);
            dbContext.Set<T>().Remove(obj);
            return dbContext.SaveChanges() > 0;
        }

        public bool Update(T t, object key)
        {
            bool result = false;
            T existing = dbContext.Set<T>().Find(key);
            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(t);
                result = dbContext.SaveChanges() > 0;
            }
            return result;
        }

        public IList<T> FindAll()
        {
            return dbContext.Set<T>().ToList<T>();
        }

        public T FindByID(object id)
        {
            return dbContext.Set<T>().Find(id);
        }
    }
}
