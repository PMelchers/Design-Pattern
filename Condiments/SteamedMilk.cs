using DecoratorPattern.Beverages;
namespace DecoratorPattern.Condiments
{
    internal class SteamedMilk : CondimentDecorator
    {
        public SteamedMilk(Beverage beverage)
        {
            this.baseBeverage = beverage;
        }

        public override double cost()
        {
            double extra = PriceBySize(0.20, 0.30, 0.40);
            return extra + baseBeverage.cost();
        }

        public override string GetDescription()
        {
            return baseBeverage.GetDescription() + ", Steamed Milk";
        }
    }
}
