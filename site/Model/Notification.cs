using System;
using System.Collections.Generic;

namespace Model
{
    public class Notification: BusinessObject
    {
        public int NotificationId { get; set; }
        public int TriggerId { get; set; }
        public string ProcessName { get; set; }
        public string Comments { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Checked { get; set; }
        public DateTime? CheckedDate { get; set; }
    }
}
