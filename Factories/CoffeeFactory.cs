using FactoryPattern.Beverages;
using FactoryPattern.Condiments;

namespace FactoryPattern.Factories
{
    internal class CoffeeFactory : BeverageFactory
    {
        protected override Beverage CreateBeverage(CoffeeType type)
        {
            switch (type)
            {
                case CoffeeType.Espresso:
                    return new Espresso();
                case CoffeeType.Doppio:
                    return new Espresso(new Espresso());
                case CoffeeType.Lungo:
                    return new Water(new Espresso());
                case CoffeeType.Macchiato:
                    return new MilkFoam(new Espresso());
                case CoffeeType.Corretta:
                    return new Liquor(new Espresso());
                case CoffeeType.ConPanna:
                    return new Whip(new Espresso());
                case CoffeeType.Cappuccino:
                    return new MilkFoam(new SteamedMilk(new Espresso()));
                case CoffeeType.Americano:
                    return new Water(new Water(new Espresso()));
                case CoffeeType.CaffeLatte:
                    return new MilkFoam(new SteamedMilk(new SteamedMilk(new Espresso())));
                case CoffeeType.FlatWhite:
                    return new SteamedMilk(new SteamedMilk(new Espresso()));
                case CoffeeType.Romana:
                    return new Lemon(new Espresso());
                case CoffeeType.Morocchino:
                    return new MilkFoam(new ChocolateSauce(new Espresso()));
                case CoffeeType.Mocha:
                    return new Whip(new SteamedMilk(new ChocolateSauce(new Espresso())));
                case CoffeeType.Bicerin:
                    return new Whip(new WhiteChocolate(new BlackChocolate(new Espresso())));
                case CoffeeType.Breve:
                    return new HalfMilk(new MilkFoam(new Espresso()));
                case CoffeeType.RafCoffee:
                    return new Cream(new VanillaSugar(new Espresso()));
                case CoffeeType.MeadRaf:
                    return new Cream(new Honey(new Espresso()));
                case CoffeeType.Galao:
                    return new MilkFoam(new MilkFoam(new Espresso()));
                case CoffeeType.CaffeAffogato:
                    return new IceCream(new Espresso(new Espresso()));
                case CoffeeType.ViennaCoffee:
                    return new Whip(new Whip(new Espresso(new Espresso())));
                case CoffeeType.Glace:
                    return new IceCream(new Espresso());
                case CoffeeType.ChocolateMilk:
                    return new Milk(new Milk(new Chocolate()));
                case CoffeeType.DemiCreme:
                    return new Cream(new Cream(new Espresso(new Espresso())));
                case CoffeeType.LatteMacchiato:
                    return new MilkFoam(new SteamedMilk(new SteamedMilk(new Espresso())));
                case CoffeeType.Freddo:
                    return new Ice(new Liquor(new Espresso()));
                case CoffeeType.Frappuccino:
                    return new Whip(new SteamedMilk(new Ice(new Espresso())));
                case CoffeeType.CaramelFrappuccino:
                    return new Syrup(new Cream(new SteamedMilk(new Ice(new Espresso()))));
                case CoffeeType.Frappe:
                    return new IceCream(new SteamedMilk(new SteamedMilk(new Espresso())));
                case CoffeeType.IrishCoffee:
                    return new Whip(new Whiskey(new Espresso(new Espresso())));
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "This coffee cannot be ordered");
            }
        }
    }
}
