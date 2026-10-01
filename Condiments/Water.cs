using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class Water : CondimentDecorator
    {
        public Water(Beverage beverage) : base(beverage, "Water", 0.50, 0.60, 0.70)
        {
        }
    }
}
