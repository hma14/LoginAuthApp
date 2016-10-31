using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationApp.Controllers
{
    public class BaseController : Controller
    {
        public readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        public System.Diagnostics.EventLog eventLog;

        public BaseController()
        {
            
            CreateLogger();
        }

        public LogEventInfo SetLogData(string msg)
        {
            return new LogEventInfo(LogLevel.Info, ConfigurationManager.AppSettings["EventLogSource"], msg);
        }

        private void CreateLogger()
        {
            eventLog = new System.Diagnostics.EventLog();
            var logSource = ConfigurationManager.AppSettings["EventLogSource"];
            var logName = ConfigurationManager.AppSettings["EventLog"];
            if (!System.Diagnostics.EventLog.SourceExists(logSource))
            {
                System.Diagnostics.EventLog.CreateEventSource(logSource, logName);
            }
            eventLog.Source = logSource;
            eventLog.Log = logName;
        }
    }
}