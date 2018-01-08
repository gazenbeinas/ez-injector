using System;
using System.Collections.Generic;
using System.Linq;
using EzInjector.Core.Resolutions.Models;
using EzInjector.Core.Resolutions.Models.Abstracts;
using EzInjector.Core.Resolutions.Services.Implementations;

namespace EzInjector.Core
{
    public class Container
    {
        public static Container Instance = new Container();

        static readonly List<Resolution> Resolutions =
            new List<Resolution>();

        public Container() =>
            Resolutions?.Clear();

        public void RegisterSingleton<T>()
            where T : class
        {
            Resolutions.Add(new SingletonResolution
            {
                ConcreteType = typeof(T)
            });
        }

        public void RegisterSingleton<TAbstract, TConcrete>()
            where TConcrete : class, TAbstract
        {
            Resolutions.Add(new SingletonResolution
            {
                AbstractType = typeof(TAbstract),
                ConcreteType = typeof(TConcrete)
            });
        }

        public void RegisterTransient<TAbstract, TConcrete>()
            where TConcrete : class, TAbstract
        {
            Resolutions.Add(new TransientResolution
            {
                AbstractType = typeof(TAbstract),
                ConcreteType = typeof(TConcrete)
            });
        }

        public Resolution FindByConcreteType(Type type) =>
            Resolutions.FirstOrDefault(r =>
            r.ConcreteType == type ||
            r.AbstractType == type);

        public T Resolve<T>()
            where T : class =>
            (T)Resolve(typeof(T));

        public object Resolve(Type resolvingType)
        {
            if (TypeIsNotMapped(resolvingType))
                return TransientService.Instance.Create(resolvingType);

            return FindByConcreteType(resolvingType)
                .Initialize();
        }

        static bool TypeIsNotMapped(Type resolvingType) =>
            Resolutions.All(x =>
                x.ConcreteType != resolvingType &&
                x.AbstractType != resolvingType);
    }
}