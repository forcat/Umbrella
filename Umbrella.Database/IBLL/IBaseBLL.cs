using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Database.IBLL
{
    public interface IBaseBLL<T> where T : class
    {
        bool Insert(T t);
        bool Delete(object id);
        bool Delete(T t);
        bool Update(T t, object key);
        T FindByID(object id);
        IList<T> FindAll();
    }
}
