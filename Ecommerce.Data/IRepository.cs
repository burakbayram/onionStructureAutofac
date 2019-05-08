using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> GetAll(params string[] navigations);
        IList<T> GetAll(Expression<Func<T, bool>> where, params string[] navigations);
        T Get(string id, params string[] navigations);
        T Get(Expression<Func<T, bool>> where, params string[] navigations);/// <summary>
        /// where shout firstordefaulttada kullanabilyorum
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
