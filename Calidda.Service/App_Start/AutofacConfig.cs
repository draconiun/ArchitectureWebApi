using Autofac;
using Autofac.Integration.WebApi;
using Calidda.Application.Employees.Commands.CreateEmployees;
using Calidda.Application.Employees.Commands.CreateEmployees.Factory;
using Calidda.Application.Employees.Commands.DeleteEmployees;
using Calidda.Application.Employees.Commands.UpdateEmployees;
using Calidda.Application.Employees.Commands.UpdateEmployees.Factory;
using Calidda.Application.Employees.Queries.ExistEmployee;
using Calidda.Application.Employees.Queries.GetEmployeeById;
using Calidda.Application.Employees.Queries.GetEmployees;
using Calidda.Application.Interfaces;
using Calidda.Persistance;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Calidda.Service
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config, IAppBuilder app)
        {
            #region Configuration
            var builder = new ContainerBuilder();

            builder.RegisterType<DatabaseService>().As<IDatabaseService>();
            builder.RegisterType<GetEmployeesQuery>().As<IGetEmployeesQuery>();
            builder.RegisterType<CreateEmployeeCommand>().As<ICreateEmployeeCommand>();
            builder.RegisterType<UpdateEmployeeCommand>().As<IUpdateEmployeeCommand>();
            builder.RegisterType<DeleteEmployeeCommand>().As<IDeleteEmployeeCommand>();
            builder.RegisterType<GetEmployeeByIdQuery>().As<IGetEmployeeByIdQuery>();
            builder.RegisterType<ExistEmployeeQuery>().As<IExistEmployeeQuery>();
            

            #region Factory

            builder.RegisterType<CreateEmployeeFactory>().As<ICreateEmployeeFactory>();
            builder.RegisterType<UpdateEmployeeFactory>().As<IUpdateEmployeeFactory>();

            #endregion

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            #endregion
        }
    }
}