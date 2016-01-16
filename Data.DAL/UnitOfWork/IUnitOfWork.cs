using System;
using System.Linq;

namespace Data.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Attach<T>(T obj) where T : class;
        void Add<T>(T obj) where T : class;
        bool Remove<T>(T obj) where T : class;

        IQueryable<T> Get<T>() where T : class;
    }
}