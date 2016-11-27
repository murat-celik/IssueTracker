using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IssueTracker.AppCode
{
    public class IssueTrackerRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private DbSet<T> _DbSet;

        public IssueTrackerRepository(IssueTrackerContext db)
        {
            this._DbSet = db.Set<T>();
        }

        public void Insert(T Entity)
        {
            Entity.UserUpdatedID = 1; //sonra düşünülecek
            Entity.UserCreatedID = 1; //sonra düşün

            Entity.DateTimeCreated = DateTime.Now;
            Entity.DateTimeUpdated = DateTime.Now;

            this._DbSet.Add(Entity);
        }


        public void Update(T Entity)
        {
            Entity.UserUpdatedID = 1; //sonra düşünülecek
            Entity.DateTimeUpdated = DateTime.Now;

            this._DbSet.Attach(Entity);
        }

        public T FindById(object EntityId)
        {
            return _DbSet.Find(EntityId);
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> Filter = null, List<string> Includes = null)
        {
            IQueryable<T> oQuery = this._DbSet;
            foreach (string item in Includes)
            {
                oQuery = oQuery.Include(item);
            }

            if (Filter != null)
            {
               
                return oQuery.Where(Filter);
            }

            return oQuery;
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