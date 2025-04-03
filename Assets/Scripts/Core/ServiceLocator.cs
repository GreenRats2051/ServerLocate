using System;
using System.Collections.Generic;

public class ServiceLocator : IServiceLocator
{
    private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public void RegisterService<T>(T service)
    {
        _services[typeof(T)] = service;
    }

    public bool GetService<T>(out T service)
    {
        if (_services.TryGetValue(typeof(T), out var obj))
        {
            service = (T)obj;
            return true;
        }

        service = default;
        return false;
    }
}