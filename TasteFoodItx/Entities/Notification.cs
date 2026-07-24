using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteFoodItx.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public DateTime Date { get; set; }
        public string description { get; set; }
        public bool IsRead { get; set; }
        public string NotificationIcon { get; set; }
        public string IconCircleColor { get; set; }
    }
}