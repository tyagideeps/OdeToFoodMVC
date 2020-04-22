using Autofac;
using Autofac.Integration.Mvc;
using OdeToFoodData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoodWeb
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlRestaurantData>()
                   .As<IRestaurantData>()
                   .InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}