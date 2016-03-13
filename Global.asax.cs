using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace WebApplication1
{
    public interface IFoobar
    {
    }

    public class Foobar : IFoobar
    {
    }

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new WindsorContainer();
            container.Register(Component.For<IFoobar>().ImplementedBy<Foobar>().LifestylePerWebRequest());

            // blows up here
            var foobar = container.Resolve<IFoobar>();
        }
    }
}
