using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class HalfMilk : CondimentDecorator
    {
        public HalfMilk(Beverage beverage) : base(beverage, "Half Milk", 0.40, 0.60, 0.80)
        {
        }
    }
}
