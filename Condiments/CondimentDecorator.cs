using DecoratorPattern.Beverages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Condiments
{
    internal abstract class CondimentDecorator : Beverage
    {
        protected CondimentDecorator()
        {
        }

        public abstract override string GetDescription();
        protected double PriceBySize(double tall, double grande, double vendi)
        {
            var s = baseBeverage != null ? baseBeverage.Size : this.Size;
            switch (s)
            {
                case DecoratorPattern.Beverages.Size.GRANDE:
                    return grande;
                case DecoratorPattern.Beverages.Size.VENDI:
                    return vendi;
                default:
                    return tall;
            }
        }

    }
}
