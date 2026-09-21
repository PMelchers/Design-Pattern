using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Beverages
{
    internal class Chocolate : Beverage
    {
        public Chocolate(Beverage beverage = null, Size? size = null)
        {
            description = "Chocolate";
            this.baseBeverage = beverage;
            if (beverage != null)
            {
                this.Size = beverage.Size;
            }
            else if (size.HasValue)
            {
                this.Size = size.Value;
            }
        }

        public override string GetDescription()
        {
            if (baseBeverage != null)
            {
                return baseBeverage.GetDescription() + ", " + description;
            }
            return description;
        }

        public override double cost()
        {
            if (baseBeverage != null)
            {
                return 1.50 + baseBeverage.cost();
            }
            return 1.50;
        }
    }
}
