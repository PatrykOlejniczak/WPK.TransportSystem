using System;
using System.Web;
using Autofac;
using Autofac.Integration.Wcf;
using Business.Services.Config;

namespace Host.WCF
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AutoMapperConfiguration.AutoConfig();

            IContainer container = AutofacContainerBuilder.BuildContainer();

            AutofacHostFactory.Container = container;
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

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}