using ObserverPattern.Interfaces;
using System;

namespace ObserverPattern.Displays
{
	internal abstract class WeatherDisplays : Observer, DisplayElement
	{
		public abstract void Update(float temp, float humidity, float pressure);
		public abstract void Display();
	}
}

