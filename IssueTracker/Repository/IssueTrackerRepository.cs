using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IssueTracker.Repository
{
    public class IssueTrackerRepository<T> : IRepository<T> where T : class, AppCode.IBaseEntity
    {
        private DbSet<T> _DbSet;
        private IssueTracker.AppCode.IssueTrackerContext _Context;

        public IssueTrackerRepository(AppCode.IssueTrackerContext Context)
        {
            this._Context = Context;
            this._DbSet = Context.Set<T>();
        }

        public void Insert(T Entity)
        {
            Entity.UserUpdatedID = 1; //sonra düşünülecek
            Entity.UserCreatedID = 1; //sonra düşün

            Entity.Status = AppCode.StatusEnum.Active;

            Entity.DateTimeCreated = DateTime.Now;
            Entity.DateTimeUpdated = DateTime.Now;

            this._DbSet.Add(Entity);
        }


        public void Update(T Entity)
        {
            Entity.UserUpdatedID = 1; //sonra düşünülecek
            Entity.DateTimeUpdated = DateTime.Now;

            this._DbSet.Attach(Entity);
            this._Context.Entry(Entity).State = EntityState.Modified;
        }

        public void Save(T Entity)
        {
            if (Entity.IsNewRecord())
            {
                Insert(Entity);
            }
            else
            {
                Update(Entity);
            }

        }

        public T FindById(int EntityId)
        {
            return _DbSet.Find(EntityId);
        }

        public T FindById(int EntityId, params string[] Includes)
        {
            IQueryable<T> oQuery = this._DbSet;
            if (Includes.Length > 0)
            {
                foreach (string item in Includes)
                {
                    oQuery = oQuery.Include(item);
                }

            }
            return oQuery.Where(w => w.ID == EntityId).FirstOrDefault<T>();
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> Filter = null, params string[] Includes)
        {
            IQueryable<T> oQuery = this._DbSet;
            if (Includes.Length > 0)
            {
                foreach (string item in Includes)
                {
                    oQuery = oQuery.Include(item);
                }

            }

            if (Filter != null)
            {

                return oQuery.Where(Filter);
            }

            return oQuery;
        }

        public void Delete(int EntityId)
        {
            T Entity = _DbSet.Find(EntityId); // bu EntityId gerçekten Db de varmı ? 
            if (Entity != null)
            {
                this.Delete(Entity);
            }
        }

        public void Delete(T Entity)
        {
            if (this._Context.Entry(Entity).State == EntityState.Detached) //Concurrency için
            {
                _DbSet.Attach(Entity);
            }
            _DbSet.Remove(Entity);
        }

    }
}