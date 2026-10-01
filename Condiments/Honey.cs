using DecoratorPattern.Beverages;

namespace DecoratorPattern.Condiments
{
    internal class Honey : CondimentDecorator
    {
        public Honey(Beverage beverage) : base(beverage, "Honey", 0.15, 0.20, 0.30)
        {
        }
    }
}
