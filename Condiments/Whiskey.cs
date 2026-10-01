using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class Whiskey : CondimentDecorator
    {
        public Whiskey(Beverage beverage) : base(beverage, "Whiskey", 0.90, 1.20, 1.50)
        {
        }
    }
}
