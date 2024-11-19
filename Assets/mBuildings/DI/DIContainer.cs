using System;
using System.Collections.Generic;

namespace DI
{
    public class DIContainer
    {
        private readonly DIContainer _privateContainer;
        private readonly Dictionary<(string, Type), DIRegistration> _registrations = new();
        
        public DIContainer(DIContainer parentContainer)
        {
            _privateContainer = parentContainer;
        }

        public void RegisterSingleton<T>(Func<DIContainer, T> factory)
        {
            RegisterSingleton(null, factory);
        }
        
        public void RegisterSingleton<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            Register(key, factory, true);
        }
        
        public void RegisterTransient<T>(Func<DIContainer, T> factory)
        {
            RegisterTransient(null, factory);
        }
        
        public void RegisterTransient<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            Register(key, factory, true);
        }

        public void RegisterInstance<T>(T instance)
        {
            RegisterInstance(null, instance);
        }
        
        public void RegisterInstance<T>(string tag, T instance)
        {
            var key = (tag, typeof(T));
            
            if (_registrations.ContainsKey(key))
            {
                throw new Exception(
                    $"DI: Factory with tag {key.Item1} and type {key.Item2.FullName} has already registered"
                );
            }

            _registrations[key] = new DIRegistration
            {
                Instance = instance,
                IsSingleton = true
            };
        }

        private void Register<T>((string, Type) key, Func<DIContainer, T> factory, bool isSingleton)
        {
            if (_registrations.ContainsKey(key))
            {
                throw new Exception(
                    $"DI: Factory with tag {key.Item1} and type {key.Item2.FullName} has already registered"
                );
            }

            _registrations[key] = new DIRegistration
            {
                Factory = c => factory,
                IsSingleton = isSingleton
            };
        }
    
    }    
}

