using Autofac;
using FluentValidation;
using System;


namespace BusinessApp_AsgaTech.WebAPI.Core
{
    public sealed class ValidatorFactory : IValidatorFactory
    {
        readonly IContainer _container;

        public ValidatorFactory(IContainer container)
        {
            _container = container;
        }

        public IValidator GetValidator(Type type)
        {
            IValidator validator = _container.ResolveOptionalKeyed<IValidator>(type);
            return validator;
        }

        public IValidator<T> GetValidator<T>()
        {
            IValidator<T> validator = _container.ResolveOptionalKeyed<IValidator<T>>(typeof(T));
            return validator;
        }
    }
}