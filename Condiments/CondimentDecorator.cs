using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal abstract class CondimentDecorator : Beverage
    {
        private readonly string name;
        private readonly double tallPrice;
        private readonly double grandePrice;
        private readonly double vendiPrice;

        protected CondimentDecorator(Beverage beverage, string name, double tallPrice, double grandePrice, double vendiPrice)
        {
            this.baseBeverage = beverage;
            this.name = name;
            this.tallPrice = tallPrice;
            this.grandePrice = grandePrice;
            this.vendiPrice = vendiPrice;
        }

        public override string GetDescription()
        {
            return baseBeverage!.GetDescription() + ", " + name;
        }

        public override double cost()
        {
            return PriceBySize() + baseBeverage!.cost();
        }

        private double PriceBySize()
        {
            switch (Size)
            {
                case Size.GRANDE:
                    return grandePrice;
                case Size.VENDI:
                    return vendiPrice;
                default:
                    return tallPrice;
            }
        }
    }
}
