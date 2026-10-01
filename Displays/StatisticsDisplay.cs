using ObserverPattern.Interfaces;
using System;

namespace ObserverPattern.Displays
{
    internal class StatisticsDisplay : WeatherDisplays
    {
        private float sumTemperature = 0;
        private float maxTemp = 0;
        private float minTemp = 0;
        private int countUpdated = 0;

        public StatisticsDisplay(Subject weatherData) : base(weatherData)
        {
        }

        protected override void OnMeasurementsChanged()
        {
            sumTemperature += temperature;
            countUpdated++;

            if (countUpdated == 1)
            {
                // First measurement: set both max and min to this value
                maxTemp = temperature;
                minTemp = temperature;
            }
            else
            {
                if (temperature > maxTemp)
                {
                    maxTemp = temperature;
                }
                if (temperature < minTemp)
                {
                    minTemp = temperature;
                }
            }
        }

        public override void Display()
        {
            float avgTemp = sumTemperature / countUpdated;
            Console.WriteLine($"Statistics - Avg Temp: {avgTemp}, Max Temp: {maxTemp}, Min Temp: {minTemp}");
        }
    }
}
