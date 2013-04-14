using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CG.Services.interfaces;

namespace CGControlPanel.Dialogs
{
    public partial class Notifications : System.Web.UI.Page
    {
        public INotificationService NotificationService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var notifications = NotificationService.GetNotifications(User.Identity.Name);
            var message = string.Empty;

            if (notifications.Count == 0)
            {
                ltrlBtnLegend.Text = "No hay mensajes para leer";
                return;
            }

            foreach (var notification in notifications)
            {
                var msgColor = string.Empty;

                switch (notification.Status)
                {
                    case "W": 
                        msgColor = "style='border-left: 3px solid rgba(255, 255, 0, 1)'";
                        break;
                    case "E":
                        msgColor = "style='border-left: 3px solid #E7281F'";
                        break;
                    default:
                        msgColor = "style='border-left: 3px solid rgba(109, 109, 109, 0.85)'";
                        break;
                }

                message += @"<li><a href='#' " + msgColor + @">
                <span class='msgdetails'>
                <span class='name'>(" + notification.TriggerId +") " + notification.ProcessName+ @"</span> <span class='msg'>" + notification.Comments + @"</span>
                    <span class='time'>" + notification.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss") + @"</span> </span>
                            </a></li>";
            }


            ltrlBtnLegend.Text = "Leer todos los mensajes";
            ltrlMessages.Text = message;
        }
    }
}