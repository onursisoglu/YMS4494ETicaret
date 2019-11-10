using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Repository
{
   public interface IRepository<T> where T:class
    {
        // CRUD işlemlerinin tasarlanacağı yerdir. Miras alan sınıf doldurmak zorundadır.

        T Add(T entity);

        List<T> GetAll();

        T Delete(Guid id);

        void Update(T entity);

        T Find(Guid id);

        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetDefault(Expression<Func<T,bool>> exp);

        List<T> GetActive();

        int Save();


    }
}
