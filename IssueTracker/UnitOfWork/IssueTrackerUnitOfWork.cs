using System;
using System.Collections;

using IssueTracker.AppCode;
using IssueTracker.Repository;
using IssueTracker.Models;

namespace IssueTracker.UnitOfWork
{
    public class IssueTrackerUnitOfWork
    {
        private IssueTrackerContext oIssueTrackerContext = new IssueTrackerContext();
        private bool _disposed = false;


        private IssueTrackerRepository<Team> _teamRepository;
        private IssueTrackerRepository<Project> _projectRepository;
        private IssueTrackerRepository<State> _stateRepository;
        private IssueTrackerRepository<Models.Type> _typeRepository;
        private IssueTrackerRepository<Priority> _priorityRepository;
        private IssueTrackerRepository<Tag> _tagRepository;
        private IssueTrackerRepository<Board> _boardRepository;
        private IssueTrackerRepository<Column> _columnRepository;

        public IssueTrackerRepository<Team> TeamRepository
        {
            get
            {
                if (_teamRepository == null)
                    _teamRepository = new IssueTrackerRepository<Team>(oIssueTrackerContext);
                return _teamRepository;
            }
        }

        public IssueTrackerRepository<Project> ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                    _projectRepository = new IssueTrackerRepository<Project>(oIssueTrackerContext);
                return _projectRepository;
            }
        }

        public IssueTrackerRepository<State> StateRepository
        {
            get
            {
                if (_stateRepository == null)
                    _stateRepository = new IssueTrackerRepository<State>(oIssueTrackerContext);
                return _stateRepository;
            }
        }

        public IssueTrackerRepository<Models.Type> TypeRepository
        {
            get
            {
                if (_typeRepository == null)
                    _typeRepository = new IssueTrackerRepository<Models.Type>(oIssueTrackerContext);
                return _typeRepository;
            }
        }

        public IssueTrackerRepository<Priority> PriorityRepository
        {
            get
            {
                if (_priorityRepository == null)
                    _priorityRepository = new IssueTrackerRepository<Priority>(oIssueTrackerContext);
                return _priorityRepository;
            }
        }

        public IssueTrackerRepository<Tag> TagRepository
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new IssueTrackerRepository<Tag>(oIssueTrackerContext);
                return _tagRepository;
            }
        }

        public IssueTrackerRepository<Board> BoardRepository
        {
            get
            {
                if (_boardRepository == null)
                    _boardRepository = new IssueTrackerRepository<Board>(oIssueTrackerContext);
                return _boardRepository;
            }
        }

        public IssueTrackerRepository<Column> ColumnRepository
        {
            get
            {
                if (_columnRepository == null)
                    _columnRepository = new IssueTrackerRepository<Column>(oIssueTrackerContext);
                return _columnRepository;
            }
        }


        public bool Save()
        {
            try
            {
                if (this.oIssueTrackerContext.Database.CurrentTransaction == null)
                {
                    this.oIssueTrackerContext.Database.BeginTransaction();
                }

                this.oIssueTrackerContext.SaveChanges();
                this.oIssueTrackerContext.Database.CurrentTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                this.oIssueTrackerContext.Database.CurrentTransaction.Rollback();
                return false;
            }
        }

        public string GetValidationErrors()
        {
            string ErrorMessage = "";
            if (this.oIssueTrackerContext.GetValidationErrors() != null)
            {
                ErrorMessage = "<ul>";

                foreach (var item in this.oIssueTrackerContext.GetValidationErrors())
                {
                    foreach (var error in item.ValidationErrors)
                    {
                        ErrorMessage = ErrorMessage + "<li>" + error.ErrorMessage + " </li> ";
                    }

                }

                ErrorMessage = ErrorMessage + "</ul>";
            }

            return ErrorMessage;
        }

        public string GetValidationErrors(System.Web.Mvc.ModelStateDictionary ModelState)
        {
            string ErrorMessage = "";
            if (ModelState.Values.Count >0)
            {
                ErrorMessage = "<ul>";
                foreach (System.Web.Mvc.ModelState modelState in ModelState.Values)
                {

                    foreach (System.Web.Mvc.ModelError error in modelState.Errors)
                    {
                        ErrorMessage = ErrorMessage + "<li>" + error.ErrorMessage + " </li> ";
                    }
                }
                ErrorMessage = ErrorMessage + "</ul>";
            }
            return ErrorMessage;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    oIssueTrackerContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}