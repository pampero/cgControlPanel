using Quartz;
using Quartz.Impl;

namespace Services.Scheduling.impl
{
    public class QuartzScheduler
    {
        private static readonly ISchedulerFactory _schedulerFactory; 
        private static readonly IScheduler _scheduler;

        static QuartzScheduler()
        {
            _schedulerFactory = new StdSchedulerFactory();
            _scheduler = _schedulerFactory.GetScheduler(); 
        }

        public static IScheduler GetScheduler()
        {
            return _scheduler;
        } 
    }
}