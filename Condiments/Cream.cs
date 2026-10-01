using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class Cream : CondimentDecorator
    {
        public Cream(Beverage beverage) : base(beverage, "Cream", 0.25, 0.35, 0.45)
        {
        }
    }
}
