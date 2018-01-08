using System;

namespace EzInjector.Core.Exceptions
{
    public class PublicConstructorException
        : Exception
    {
        public PublicConstructorException(Type type)
            :base($"{type.Name} cannot have more than a single public constructor")
        {
        }
    }
}