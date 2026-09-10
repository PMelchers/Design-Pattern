using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Displays
{
    internal class ForecastDisplay : WeatherDisplays
    {
        private float temperature;
        private float humidity;
        private Subject weatherData;
        public ForecastDisplay(Subject weatherData) 
        { 
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public override void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display();
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
