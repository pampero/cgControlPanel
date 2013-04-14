using System;
using System.Web.UI;
using log4net;

namespace CGControlPanel
{
    public class BasePage : Page
    {
        protected static readonly ILog log = LogManager.GetLogger("LogFileAppender");
    }
}