using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data
{
  public  interface IUnitofWork
    {
        /// <summary>
        /// core da ıdispose yapmıyoruz cunki depency injection vardır.
        /// burda new yapmmamızın sebebi aynı requstte hepsi yasayacak core de dependcy den kaynaklanan bi durum
        /// </summary>
        void SaveChanges();
    }
}
