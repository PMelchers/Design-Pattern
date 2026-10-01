using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class Honey : CondimentDecorator
    {
        public Honey(Beverage beverage) : base(beverage, "Honey", 0.15, 0.20, 0.30)
        {
        }
    }
}
