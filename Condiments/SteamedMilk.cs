using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class SteamedMilk : CondimentDecorator
    {
        public SteamedMilk(Beverage beverage) : base(beverage, "Steamed Milk", 0.20, 0.30, 0.40)
        {
        }
    }
}
