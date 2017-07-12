using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Database.IDAL
{
    public interface IBaseDAL<T> where T : class
    {
        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        bool Insert(T t);

        // <summary>
        /// 根据指定对象的ID,从数据库中删除指定对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool Delete(object id);

        /// <summary>
        /// 从数据库中删除指定对象
        /// </summary>
        /// <param name="id">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool Delete(T t);

        /// <summary>
        /// 更新对象属性到数据库中
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <param name="key">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        bool Update(T t, object key);

        /// <summary>
        /// 查询数据库,返回指定ID的对象
        /// </summary>
        /// <param name="id">ID主键的值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        T FindByID(object id);

        /// <summary>
        /// 返回可查询的记录
        /// </summary>
        /// <returns></returns>
        IList<T> FindAll();
    }
}
