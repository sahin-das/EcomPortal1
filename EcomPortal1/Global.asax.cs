﻿using EcomPortal.Models;
using EcomPortal.Models.Entities;
using EcomPortal.Repositories;
using EcomPortal.Services;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace EcomPortal1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureDependencyInjection();
        }

        private void ConfigureDependencyInjection()
        {
            var container = new UnityContainer();
            
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(ICrudRepository<>), typeof(CrudRepository<>), new HierarchicalLifetimeManager());
            container.RegisterType<ICrudRepository<Order>, OrderRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<ProductService>();
            container.RegisterType<OrderService>();
            container.RegisterType<UserService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
