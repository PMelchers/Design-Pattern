using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class WhiteChocolate : CondimentDecorator
    {
        public WhiteChocolate(Beverage beverage) : base(beverage, "White Chocolate", 0.35, 0.50, 0.70)
        {
        }
    }
}
