﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using KempsTuroTuro.Data.Interface;

namespace KempsTuroTuro.Data.Repository
{
    public abstract class RepositoryBase<T, I> where T : class, new()
    {
        private KempsContext _dataContext;
        private readonly IDbSet<T> _dbset;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected KempsContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }
        public virtual T Add(T entity)
        {
            _dbset.Add(entity);
            return entity;
        }
        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }
        public virtual T GetById(I id)
        {
            return _dbset.Find(id);
        }
    
        public virtual IEnumerable<T> GetAll()
        {            
            return _dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where);
        }
    }
}
