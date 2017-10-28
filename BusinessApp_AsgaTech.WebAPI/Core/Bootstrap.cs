using Autofac;

namespace BusinessApp_AsgaTech.WebAPI.Core
{
    public class Bootstrap : IBootstrap
    {
        public void Register(ContainerBuilder builder)
        {
            builder.Register(x => new UserManagement(x.Resolve<UserQuery>()));
            builder.Register(x => new UserQuery());
        }
    }
}