using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CG.Services.interfaces;
using Model;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System.Configuration;
using Services.Exceptions;
using Utils.ADO;

namespace Services.Scheduling.impl
{
    public class DefaultNotificationService : INotificationService
    {
        public UnitOfWork UnitOfWork { get; set; }

        public List<Notification> GetNotifications(string userName)
        {
            return UnitOfWork.NotificationsRepository.GetNotifications(userName);
        }

        public int GetAllNotifications(string userName)
        {
            return UnitOfWork.NotificationsRepository.GetAllNotifications(userName);
        }

        public void CheckOne(int notificationId)
        {
            var notification = UnitOfWork.NotificationsRepository.GetNotificationById(notificationId);

            notification.Checked = true;
            notification.CheckedDate = DateTime.Now;

            UnitOfWork.NotificationsRepository.Update(notification);
            UnitOfWork.Save();
        }

        public void CheckAll(string userName)
        {
            var notifications = UnitOfWork.NotificationsRepository.GetNotifications(userName);

            foreach (var notification in notifications)
            {
                notification.Checked = true;
                notification.CheckedDate = DateTime.Now;
                UnitOfWork.NotificationsRepository.Update(notification);
            }

            UnitOfWork.Save();
        }

        
    }
}
