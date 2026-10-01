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
			this.weatherData = weatherData;
			weatherData.RegisterObserver(this);
		}

		public void Update(float temp, float humidity, float pressure)
		{
			temperature = temp;
			this.humidity = humidity;
			this.pressure = pressure;

			OnMeasurementsChanged();
			Display();
		}

		protected virtual void OnMeasurementsChanged() { }

		public abstract void Display();
	}
}
