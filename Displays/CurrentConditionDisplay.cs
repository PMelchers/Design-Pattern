using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Displays
{
    internal class CurrentConditionDisplay : WeatherDisplays
    {
        private float temperature;
        private float humidity;
        private Subject weatherData;
        public CurrentConditionDisplay(Subject weatherData) 
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
            // Print the current conditions of the weather
            Console.WriteLine($"Current Conditions - Temperature: {temperature}°C, Humidity: {humidity}%");
        }
    }
}
