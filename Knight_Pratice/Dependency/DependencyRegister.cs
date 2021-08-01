using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Knight_Pratice.ApiControllers;
using Knight_Pratice.Context;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using Knight_Pratice.Repository;
using Knight_Pratice.Services;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Knight_Pratice.Dependency
{
    public class DependencyRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterType<RedisCacheService>().As<ICacheService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FooBarQixService>().As<IDateService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<BaseRepository>().As<IDataRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<InputService>().As<IInputService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
           containerBuilder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();



        }
    }
}
