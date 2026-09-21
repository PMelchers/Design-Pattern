using DecoratorPattern.Beverages;
namespace DecoratorPattern.Condiments
{
    internal class Honey : CondimentDecorator
    {
        public Honey(Beverage beverage)
        {
            this.baseBeverage = beverage;
        }

        public override double cost()
        {
            double extra = PriceBySize(0.15, 0.20, 0.30);
            return extra + baseBeverage.cost();
        }

        public override string GetDescription()
        {
            return baseBeverage.GetDescription() + ", Honey";
        }
    }
}
