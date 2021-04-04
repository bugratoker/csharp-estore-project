using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    // bu efentityrepository bizim eski iproductdalımız yani daha gelişmişi
    // veri erişim katmanı 

    public class EfEntityRepositoryBase<TEntity, TContext> :IEntityRepository<TEntity>
        where TEntity :class,IEntity,new() 
        where TContext : DbContext,new()

    {
        public void add(TEntity entity)
        {
            using (TContext nC = new TContext())
            {
                var addedEntity = nC.Entry(entity);

                addedEntity.State = EntityState.Added;

                nC.SaveChanges();

            }
        }

        public void delete(TEntity entity)
        {
            using (TContext nC = new TContext())
            {
                var deletedEntity = nC.Entry(entity);

                deletedEntity.State = EntityState.Deleted;

                nC.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext nC = new TContext())
            {
                return nC.Set<TEntity>().SingleOrDefault(filter);

            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext nC = new TContext())
            {
                return filter == null
                    ? nC.Set<TEntity>().ToList()
                    : nC.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void update(TEntity entity)
        {
            using (TContext nC = new TContext())
            {
                var modifiedEntity = nC.Entry(entity);

                modifiedEntity.State = EntityState.Modified;

                nC.SaveChanges();

            }
        }



    }
}
