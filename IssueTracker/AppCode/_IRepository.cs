using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IssueTracker.AppCode
{
    public interface IRepository<T> where T : class
    {
        void Insert(T Entity);
        void Update(T Entity);

        void Delete(object EntityId);
        void Delete(T Entity);

        T FindById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
    }
}