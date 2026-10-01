using ObserverPattern.Interfaces;
using System;

namespace ObserverPattern.Displays
{
    internal class CurrentConditionDisplay : WeatherDisplays
    {
        public CurrentConditionDisplay(Subject weatherData) : base(weatherData)
        {
        }

        public override void Display()
        {
            // Print the current conditions of the weather
            Console.WriteLine($"Current Conditions - Temperature: {temperature}°C, Humidity: {humidity}%");
        }
    }
}
