using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage) : base(beverage, "Milk", 0.15, 0.25, 0.35)
        {
        }
    }
}
