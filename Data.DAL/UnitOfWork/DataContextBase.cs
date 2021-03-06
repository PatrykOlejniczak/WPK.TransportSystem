﻿using System;
using System.Data.Entity;
using System.Linq;

namespace Data.Core.UnitOfWork
{
    public abstract class DataContextBase : DbContext, IUnitOfWork
    {
        protected DataContextBase(string nameOrConnectionString = "FullTestDataBase")
            : base(nameOrConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void Attach<T>(T obj) where T : class
        {
            Set<T>().Attach(obj);
        }

        public void Add<T>(T obj) where T : class
        {
            Set<T>().Add(obj);
        }

        public bool Remove<T>(T obj) where T : class
        {
            try
            {
                Set<T>().Remove(obj);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return Set<T>();
        }
    }
}