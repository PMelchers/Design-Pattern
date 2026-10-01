using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class Ice : CondimentDecorator
    {
        public Ice(Beverage beverage) : base(beverage, "Ice", 0.05, 0.07, 0.10)
        {
        }
    }
}
