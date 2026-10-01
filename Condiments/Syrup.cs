using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class Syrup : CondimentDecorator
    {
        public Syrup(Beverage beverage) : base(beverage, "Syrup", 0.20, 0.30, 0.40)
        {
        }
    }
}
