using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ControlsDemo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
          
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //if (Server.GetLastError() != null)
            //{
            //    // Log the exception
            //    Logger.Log(Server.GetLastError());

            //    // Clear the exception
            //    Server.ClearError();
            //    // Transfer the user to Errors.aspx page
            //    Server.Transfer("Errors.aspx");
            //}
        }

        protected void Session_End(object sender, EventArgs e)
        {
           
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}