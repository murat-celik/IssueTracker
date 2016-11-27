using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IssueTracker.AppCode
{
    public class IssueTrackerRepository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _DbSet;

        public IssueTrackerRepository(IssueTrackerContext db)
        {
            this._DbSet = db.Set<T>();
        }

        public void Insert(T Entity)
        {
            this._DbSet.Add(Entity);
        }


        public void Update(T Entity)
        {
            this._DbSet.Attach(Entity);
        }

        public T FindById(object EntityId)
        {
            return _DbSet.Find(EntityId);
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _DbSet.Where(Filter);
            }
            return this._DbSet;
        }

        public void Delete(object EntityId)
        {
            T Entity = _DbSet.Find(EntityId); // bu EntityId gerçekten Db de varmı ? 
            if (Entity != null)
            {
                this.Delete(Entity);
            }
        }

        public void Delete(T Entity)
        {
            _DbSet.Remove(Entity);
        }

    }
}