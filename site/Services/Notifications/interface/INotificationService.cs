using System;
using System.Collections.Generic;
using Model;


namespace CG.Services.interfaces
{
    public interface INotificationService
    {
        List<Notification> GetNotifications(string userName);
        void CheckAll(string userName);
        int GetAllNotifications(string userName);
        void CheckOne(int notificationId);
    }
}