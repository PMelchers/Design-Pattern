using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class Liquor : CondimentDecorator
    {
        public Liquor(Beverage beverage) : base(beverage, "Liquor", 0.70, 0.90, 1.10)
        {
        }
    }
}
