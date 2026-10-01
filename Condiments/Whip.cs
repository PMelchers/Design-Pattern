using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage) : base(beverage, "Whip", 0.10, 0.15, 0.20)
        {
        }
    }
}
