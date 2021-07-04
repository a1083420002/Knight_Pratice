using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Autofac;
using Knight_Pratice.ApiControllers;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Services;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Knight_Pratice.Dependency
{
    public class DependencyRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            //var assembly = this.GetType().GetTypeInfo().Assembly;
            //var builder = new ContainerBuilder();
            //var manager = new ApplicationPartManager();
            //manager.ApplicationParts.Add(new AssemblyPart(assembly));
            //manager.FeatureProviders.Add(new ControllerFeatureProvider());
            //var feature = new ControllerFeature();
            //manager.PopulateFeature(feature);
            //builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            //builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
            //containerBuilder.RegisterType<NumbersController>().PropertiesAutowired();

           
            containerBuilder.RegisterType<FooBarQixService>().As<IDateService>().SingleInstance();
            containerBuilder.RegisterType<InputService>().As<IInputService>();
            containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>();

        }
    }
}
