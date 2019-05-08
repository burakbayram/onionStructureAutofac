using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> entities;
        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            entities = context.Set<T>();
        }
        public IList<T> GetAll(params string[] navigations) {
            var query = entities.AsNoTracking().AsQueryable();
            foreach (var nav in navigations)
            {
                query = query.Include(nav);
            }
            return query.ToList();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public T Get(string id,params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
            {
                query = query.Include(nav);
            }
            return query.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }


        /// <summary>
        /// sartlı kayıtyları getirir.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<T> GetAll(Expression<Func<T, bool>> where, params string[] navigations)
        {
            var query = entities.AsNoTracking().AsQueryable();
            foreach (var nav in navigations)
            {
                query = query.Include(nav);
            }
            return query.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where, params string[] navigations)
        {
            var query = entities.AsNoTracking().AsQueryable();///iclude hatalarını onlemek ıcın
            foreach (var nav in navigations)
            {
                query = query.Include(nav);
            }
            return query.Where(where).FirstOrDefault();
        }
    }
}

///foreigkey modellerimde olnları getirlen eagr loading kullan ınclude iele