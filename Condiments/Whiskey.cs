using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class Whiskey : CondimentDecorator
    {
        public Whiskey(Beverage beverage) : base(beverage, "Whiskey", 0.90, 1.20, 1.50)
        {
        }
    }
}
