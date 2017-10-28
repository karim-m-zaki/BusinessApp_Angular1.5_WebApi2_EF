using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BusinessApp_AsgaTech.WebAPI.Core;

using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace BusinessApp_AsgaTech.WebAPI.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            ContainerBuilder builder = RegisterAll();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            ModelValidatorProviders.Providers.Clear();

            //WEB API
            GlobalConfiguration.Configuration.Services.Add(
                typeof(System.Web.Http.Validation.ModelValidatorProvider),
                new FluentValidation.WebApi.FluentValidationModelValidatorProvider(new ValidatorFactory(container))
                );
        }

        private static ContainerBuilder RegisterAll()
        {
            var builder = new ContainerBuilder();
            var executingAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(executingAssembly);
            builder.RegisterApiControllers(executingAssembly);

            //perform registration
            var type = typeof(IBootstrap);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            foreach (var p in types)
            {
                var config = (IBootstrap)Activator.CreateInstance(p);
                config.Register(builder);
            }

            return builder;
        }
    }
}