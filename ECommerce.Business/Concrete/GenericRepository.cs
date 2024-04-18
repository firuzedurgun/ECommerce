using ECommerce.Business.Abstract;
using ECommerce.Data.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class GenericRepository<TEntity, Tcontext> : IGenericRepository<TEntity>
        where TEntity : class, new()
        where Tcontext : IdentityDbContext<AppUser, AppRole, int>, new()
    {
        public void Add(TEntity entity)
        {
            using(var db = new Tcontext())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Tcontext())
            {
                var entity = db.Set<TEntity>().Find(id);
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (var db = new Tcontext())
            {
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public TEntity Get(int id)
        {
            using (var db = new Tcontext())
            {
                var entity = db.Set<TEntity>().Find(id);
                return entity;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                var entity = db.Set<TEntity>().Find(filter);
                return entity;
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return filter == null ? db.Set<TEntity>().ToList() : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
           using (var db = new Tcontext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
