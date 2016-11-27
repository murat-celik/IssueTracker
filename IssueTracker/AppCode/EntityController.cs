using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IssueTracker.AppCode
{
    public class EntityController<T> where T : class, IBaseEntity
    {
        public EntityController(IssueTrackerFacede Application)
        {
            this.oApplication = Application;
        }

        private IssueTrackerFacede oApplication;

        public IssueTrackerFacede Application
        {
            get
            {
                return this.oApplication;
            }
        }

        public IssueTrackerUnitOfWork oIssueTrackerUnitOfWork
        {
            get
            {
                return this.Application.oIssueTrackerUnitOfWork;
            }
        }

        public IssueTrackerRepository<T> oIssueTrackerRepository
        {
            get
            {
                return this.oIssueTrackerUnitOfWork.CreateRepository<T>();
            }
        }


        public T Save(T Entity)
        {
            if (Entity.ID == 0)
                this.oIssueTrackerRepository.Insert(Entity);
            else
                this.oIssueTrackerRepository.Update(Entity);
            this.oIssueTrackerUnitOfWork.Save();
            return Entity;
        }

        public bool Delete(int id)
        {
            this.oIssueTrackerRepository.Delete(id);
            this.oIssueTrackerUnitOfWork.Save();
            return true;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> Filter = null,List<string> Includes = null)
        {
            return this.oIssueTrackerRepository.Select(Filter, Includes);
        }
    }
}