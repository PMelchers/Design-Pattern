using ObserverPattern.Interfaces;
using System;

namespace ObserverPattern.Displays
{
	internal abstract class WeatherDisplays : Observer, DisplayElement
	{
		protected float temperature;
		protected float humidity;
		protected float pressure;
		protected readonly Subject weatherData;

		protected WeatherDisplays(Subject weatherData)
		{
			// Every display subscribes itself to the subject when it is created
			this.weatherData = weatherData;
			weatherData.RegisterObserver(this);
		}

		public void Update(float temp, float humidity, float pressure)
		{
			// Every display stores the new measurements and shows itself afterwards
			temperature = temp;
			this.humidity = humidity;
			this.pressure = pressure;

			OnMeasurementsChanged();
			Display();
		}

		// Hook for displays that need to do extra work before they are shown
		protected virtual void OnMeasurementsChanged() { }

		public abstract void Display();
	}
}
