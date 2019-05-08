using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data
{
    public class UnitofWork : IUnitofWork
    {

        /// <summary>
        /// unitofwork resositoryler icin transaction yonetimi için kullanılır;aynı db insr-tance uzerşnde n
        /// </summary>
        private readonly ApplicationDbContext _context;
        public UnitofWork(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
