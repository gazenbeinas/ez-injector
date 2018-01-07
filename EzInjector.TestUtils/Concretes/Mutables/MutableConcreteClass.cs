namespace EzInjector.TestUtils.Concretes.Mutables
{
    public class MutableConcreteClass
    {
        private int _value;

        public void IncreaseValue() => _value++;
        public int GetValue() => _value;
    }
}