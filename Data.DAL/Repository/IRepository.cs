using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Data.Core.UnitOfWork;

namespace Data.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        void EnrollUnitOfWork(IUnitOfWork unitOfWork);

        int Count { get; }

        void Add(T obj);
        void Remove(T obj);

        bool Contains(T obj);

        IQueryable<T> FindAll();
        IQueryable<T> FindAll(string lazyIncludeStrings);
        IQueryable<T> FindAll(Func<DbSet<T>, IQueryable<T>> lazySetupAction);
        IQueryable<T> FindBy(Func<T, bool> predicate);
        IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Func<T, bool> predicate, string lazyIncludeStrings);
        IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate, string lazyIncludeStrings);
    }
}