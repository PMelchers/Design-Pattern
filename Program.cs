using ObserverPattern.Displays;

namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            // Create instances of displays 
            CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);

            Console.WriteLine("=== First measurement set ===");
            weatherData.SetMeasurements(28, 65, 30.4f);

            Console.WriteLine("\n=== Second measurement set ===");
            weatherData.SetMeasurements(29, 70, 29.2f);

            Console.WriteLine("\n=== Third measurement set ===");
            weatherData.SetMeasurements(30, 90, 29.2f);

            Console.WriteLine("\n=== Unsubscribing ForecastDisplay ===");
            weatherData.RemoveObserver(forecastDisplay);

            Console.WriteLine("\n=== Fourth measurement set (ForecastDisplay unsubscribed) ===");
            weatherData.SetMeasurements(25, 55, 31.0f);
        }
    }
}