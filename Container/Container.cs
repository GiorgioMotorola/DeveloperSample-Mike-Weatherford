using System;

namespace DeveloperSample.Container
{
    public class Container
    {
        public void Bind(Type interfaceType, Type implementationType)
        {
            bindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            Type interfaceType = typeof(T);
            if (!interfaceType.IsInterface)
                throw new ArgumentException("must be an interface.");

            if (!bindings.TryGetValue(interfaceType, out Type implementationType))
                throw new InvalidOperationException("No implementation found.");

            object instance = Activator.CreateInstance(implementationType);
            return (T)instance;
        }
    }
}