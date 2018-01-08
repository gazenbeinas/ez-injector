using EzInjector.Core;

namespace EzInjector.Resolution
{
    public class IoC
    {
        static readonly Container Container =
            new Container();

        public static T Get<T>()
            where T : class =>
            Container.Resolve<T>();

        public static void RegisterSingleton<T>()
            where T : class =>
            Container.RegisterSingleton<T>();

        public static void RegisterSingleton<TAbstract, TConcrete>()
            where TConcrete : class, TAbstract =>
            Container.RegisterSingleton<TAbstract, TConcrete>();

        public static void RegisterTransient<TAbstract, TConcrete>()
            where TConcrete : class, TAbstract =>
            Container.RegisterTransient<TAbstract, TConcrete>();
    }
}