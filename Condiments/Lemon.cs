using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class Lemon : CondimentDecorator
    {
        public Lemon(Beverage beverage) : base(beverage, "Lemon", 0.05, 0.08, 0.12)
        {
        }
    }
}
