using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAL
{
    public class NotificationsRepository : GenericRepository<Notification>
    {
        public NotificationsRepository(CGControlPanelContext context) : base(context)
        {
            
        }

        // Retorna las primeras 5
        public List<Notification> GetNotifications(string userName)
        {
            return context.Notifications.Where(t => !t.Checked && t.UserName == userName).OrderBy(t => t.CreatedDate).Take(5).ToList();
        }

        public int GetAllNotifications(string userName)
        {
            return context.Notifications.Where(t => !t.Checked && t.UserName == userName).OrderBy(t => t.CreatedDate).Count();
        }

        public Notification GetNotificationById(int notificationId)
        {
            return context.Notifications.SingleOrDefault(t => t.NotificationId == notificationId);
        }

        public void CheckAll(string userName)
        {
            var notifications = context.Notifications.Where(t => !t.Checked && t.UserName == userName).OrderBy(t => t.CreatedDate).Take(5).ToList();

            foreach (var notification in notifications)
            {
                notification.Checked = true;
                notification.CheckedDate = DateTime.Now;
            }
        }

        public void CheckOne(string userName, int notificationId)
        {
            var notification = context.Notifications.SingleOrDefault(t => t.NotificationId == notificationId);

            if (notification != null)
            {
                notification.Checked = true;
                notification.CheckedDate = DateTime.Now;
            }
        }
    }
}
