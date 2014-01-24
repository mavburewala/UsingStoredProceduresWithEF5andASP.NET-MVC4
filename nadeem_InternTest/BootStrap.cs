using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using nadeem_InternTest.DAL;
using nadeem_InternTest.Models;
using System.Reflection;

namespace nadeem_InternTest
{
    // Bootstrap class for Autofac
    public class BootStrap
    {
        public IContainer myContainer { get; private set; }

        public void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            OnConfigure(builder);

            if (this.myContainer == null)
            {
                this.myContainer = builder.Build();
            }
            else
            {
                builder.Update(this.myContainer);
            }

            //This tells the MVC application to use myContainer as its dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(this.myContainer));
        }


        protected virtual void OnConfigure(ContainerBuilder builder)
        {
            //This is where you register all dependencies

            //The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //The line below tells autofac, everytime an implementation IDAL is needed, pass in an instance of the class DAL
            builder.RegisterType<DatabaseRetriever>().As<IDAL>().InstancePerLifetimeScope();


        }
    }
}