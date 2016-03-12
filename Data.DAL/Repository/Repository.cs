using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Data.Core.UnitOfWork;

namespace Data.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IUnitOfWork UnitOfWork;

        public void EnrollUnitOfWork(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public int Count
        {
            get { return UnitOfWork.Get<T>().Count(); }
        }

        public void Add(T obj)
        {
            UnitOfWork.Add(obj);
        }

        public void Remove(T obj)
        {
            UnitOfWork.Remove(obj);
        }

        public bool Contains(T obj)
        {
            return UnitOfWork.Get<T>().FirstOrDefault(o => o == obj) != null;
        }

        public IQueryable<T> FindAll()
        {
            return UnitOfWork.Get<T>();
        }

        public IQueryable<T> FindAll(string lazyIncludeStrings)
        {
            DbSet<T> dbSet = (DbSet<T>) UnitOfWork.Get<T>();

            return dbSet.Include(lazyIncludeStrings).AsQueryable();
        }

        public IQueryable<T> FindAll(Func<DbSet<T>, IQueryable<T>> lazySetupAction)
        {
            DbSet<T> dbSet = (DbSet<T>) UnitOfWork.Get<T>();

            return lazySetupAction(dbSet);
        } 

        public IQueryable<T> FindBy(Func<T, bool> predicate)
        {
            return UnitOfWork.Get<T>().Where(predicate).AsQueryable();
        }

        public IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate)
        {
            return UnitOfWork.Get<T>().Where(predicate).AsQueryable();
        }

        public IQueryable<T> FindBy(Func<T, bool> predicate, string lazyIncludeStrings)
        {
            DbSet<T> dbSet = (DbSet<T>) UnitOfWork.Get<T>();

            return dbSet.Include(lazyIncludeStrings).Where(predicate).AsQueryable();
        }

        public IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate, string lazyIncludeStrings)
        {
            return UnitOfWork.Get<T>().Where(predicate).AsQueryable();
        }
    }
}