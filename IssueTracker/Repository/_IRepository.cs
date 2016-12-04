using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IssueTracker.Repository
{
    public interface IRepository<T> where T : class, AppCode.IBaseEntity
    {
        void Insert(T Entity);
        void Update(T Entity);

        void Delete(int EntityId);
        void Delete(T Entity);

        T FindById(int EntityId);
        T FindById(int EntityId, List<string> Includes = null);
        IQueryable<T> Select(Expression<Func<T, bool>> Filter = null, List<string> Includes = null);
    }
}