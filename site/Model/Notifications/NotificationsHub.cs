using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using SignalR;

namespace CGControlPanel.Notifications
{
    [HubName("Notification")]
  public class NotificationHub : Hub 
  {
      public static void Send(string message) 
      {
          var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
          context.Clients.newNotification(message);
      }

        public void send2(string message)
        {
            Send(message);
        }
  }
}