using Autofac;
using System.Web.UI;

namespace BusinessApp_AsgaTech.WebAPI.Core
{
    public interface IBootstrap
    {
        void Register(ContainerBuilder builder);
    }

    public static class ValidatorBootStrap
    {
        public static void Config<T, K>(this ContainerBuilder b)
            where T : class
            where K : class
        {
            b.RegisterType<T>().Keyed<IValidator>(typeof(K)).As<IValidator>();
        }
    }
}