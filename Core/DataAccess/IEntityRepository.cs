
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    //eyvallah T dedik de her <T> de olmaz bunun için where ile class olması IEntity'i imp. etmesi
    //ve newlenebilir olmalı.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        // Generic Repository Design Pattern
        List<T> GetAll(Expression<Func<T,bool>> filter =null);

        T Get(Expression<Func<T, bool>> filter);
        void add(T entity);
        void update(T entity);
        void delete(T entity);
        


    }
}
