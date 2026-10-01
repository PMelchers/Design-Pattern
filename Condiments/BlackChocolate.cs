using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class BlackChocolate : CondimentDecorator
    {
        public BlackChocolate(Beverage beverage) : base(beverage, "Black Chocolate", 0.35, 0.50, 0.70)
        {
        }
    }
}
