using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class MilkFoam : CondimentDecorator
    {
        public MilkFoam(Beverage beverage) : base(beverage, "Milk Foam", 0.05, 0.08, 0.12)
        {
        }
    }
}
