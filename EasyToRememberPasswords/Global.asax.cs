﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Routing;

namespace EasyToRememberPasswords
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Get reference to the source of the exception.
            var ex = sender as Exception;

            if (ex == null)
                ex = Server.GetLastError();

            new LogEvent(ex.ToString()).Raise();
        }

        public class LogEvent : WebRequestErrorEvent
        {
            public LogEvent(string message) : base(null, null, 100001, new Exception(message))
            {
            }
        }
    }
}