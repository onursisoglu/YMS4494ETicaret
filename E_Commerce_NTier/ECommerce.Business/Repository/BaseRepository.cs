using ECommerce.Data.Context;
using ECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        ECommerceContext db;
        DbSet<T> table;
        public BaseRepository()
        {
            db = new ECommerceContext();
            table = db.Set<T>();

        }

        public T Add(T entity)
        {
            if (entity != null)
            {
                entity.AddedDate = DateTime.Now;
                entity.IsActive = true;
                table.Add(entity);
                Save();
            }
            return entity;
        }

        public T Delete(Guid id)
        {
            // önce silinecek veriyi bulalım.
            var removeEntity = Find(id);

            if (removeEntity != null)
            {
                removeEntity.IsActive = false;
                Save();
            }

            return removeEntity;

        }

        public T Find(Guid id)
        {
            return table.Find(id);
        }

        public List<T> GetActive()
        {
            return table.Where(x => x.IsActive).ToList(); // active kolonu true olanları geri döndürür.
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return table.FirstOrDefault(exp);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList(); // dışardan gelen lambda sorgusuna göre listeyi dönecektir.
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public void Update(T entity) // güncellenmiş veri parametreye gelir
        {
            if (entity != null)
            {
                // Önce veritabanında güncellenecek orjinal entity ' i bulmak gereklidir.
                var updateEntity = Find(entity.ID);
                // Güncellenmiş parametredeki verinin  updateDate ' ini dolduralım.
                entity.UpdatedDate = DateTime.Now;

                // Güncellenmiş parametredeki verinin değerlerini orjinal veriye set et (ata);
                db.Entry(updateEntity).CurrentValues.SetValues(entity);
                Save();
            }
        }
    }
}
