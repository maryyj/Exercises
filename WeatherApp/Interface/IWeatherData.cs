using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Interface
{
    public interface IWeatherData
    {
        public string GetWeather();
    }
    //en kommentar
    public class WeatherData : IWeatherData
    {
        public string GetWeather()
        {
            string[] weatherStrings = {
                "Sunny all day long",
                "Raining cat and dogs",
                "Unclear",
                "Good day for eating apples",
                "Windy",
                "Local snowstorms"
            };
            var rand = new Random();
            var index = rand.Next(weatherStrings.Length);

            return weatherStrings[index];
        }
    }
    public class MockWeatherData : IWeatherData 
    {
        public string GetWeather() 
        {
            string weatherString = "Raining cat and dogs";

            return weatherString;
        }
    }
}
