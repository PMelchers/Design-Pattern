using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Displays
{
    internal class StatisticsDisplay : WeatherDisplays
    {
        private float temperature;
        private float sumTemperature = 0;
        private float maxTemp = 0;
        private float minTemp = 0;
        private int countUpdated = 0;
        private Subject weatherData;
        public StatisticsDisplay(Subject weatherData) 
        { 
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public override void Update(float temp, float humidity, float pressure)
        {
            temperature = temp;
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

            Display();
        }

        public override void Display()
        {
            float avgTemp = sumTemperature / countUpdated;
            Console.WriteLine($"Statistics - Avg Temp: {avgTemp}, Max Temp: {maxTemp}, Min Temp: {minTemp}");
        }
    }
}
