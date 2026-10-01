using ObserverPattern.Interfaces;
using System;

namespace ObserverPattern.Displays
{
    internal class ForecastDisplay : WeatherDisplays
    {
        public ForecastDisplay(Subject weatherData) : base(weatherData)
        {
        }

        public override void Display()
        {
            // Generate forecast based on temperature and humidity
            string forecast;

            if (humidity > 80)
            {
                forecast = "Trek je paraplu's uit de kast";
            }
            else if (temperature > 25)
            {
                forecast = "Mooi weer komt er aan";
            }
            else if (temperature > 15)
            {
                forecast = "Aangenaam weer verwacht";
            }
            else
            {
                forecast = "Koud weer op komst";
            }

            Console.WriteLine("Forecast: " + forecast);
        }
    }
}
