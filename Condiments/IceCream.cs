using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class IceCream : CondimentDecorator
    {
        public IceCream(Beverage beverage) : base(beverage, "Ice cream", 0.40, 0.60, 0.80)
        {
        }
    }
}
