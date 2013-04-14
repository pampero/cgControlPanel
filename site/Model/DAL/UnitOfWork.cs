using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Model;
using Model.DAL;
using System.Data.Common;

namespace Model
{
    public class UnitOfWork : IDisposable
    {
        private CGControlPanelContext context = new CGControlPanelContext();
        private JobsRepository _jobsRepository;
        private NotificationsRepository _notificationsRepository;
        private SqlJobsRepository _sqlJobsRepository;
        private JobTriggersRepository _jobTriggersRepository;

        public DbConnection GetConnection()
        {
            return context.Database.Connection;
        }

        public JobsRepository JobsRepository
        {
            get
            {

                if (this._jobsRepository == null)
                {
                    this._jobsRepository = new JobsRepository(context);
                }
                return _jobsRepository;
            }
        }

        public NotificationsRepository NotificationsRepository
        {
            get
            {
                if (this._notificationsRepository == null)
                {
                    this._notificationsRepository = new NotificationsRepository(context);
                }
                return _notificationsRepository;
            }
        }

        public SqlJobsRepository SqlJobsRepository
        {
            get
            {

                if (this._sqlJobsRepository == null)
                {
                    this._sqlJobsRepository = new SqlJobsRepository(context);
                }
                return _sqlJobsRepository;
            }
        }

        public JobTriggersRepository JobTriggerRepository
        {
            get
            {
                if(this._jobTriggersRepository== null)
                {
                    this._jobTriggersRepository = new JobTriggersRepository(context);
                }
                return _jobTriggersRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IList<Job> GetJobs()
        {
           return context.Jobs.ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}