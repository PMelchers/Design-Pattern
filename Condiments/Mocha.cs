using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage, "Mocha", 0.20, 0.30, 0.40)
        {
        }
    }
}
