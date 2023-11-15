using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Interface;

namespace WeatherApp
{
    public class WeatherService
    {
        private readonly DateTime _dateNow;

        public WeatherService(IDateTimeWrapper dateTimeWrapper)
        {
            _dateNow = dateTimeWrapper.GetNow();
        }
        public void GenerateOutputString(string? city, string weather)
        {
            Console.WriteLine($"Today is {_dateNow.DayOfWeek}");
            Console.WriteLine($"The weather in {city} is {weather}");
        }
        public string GetCityFromUser()
        {
            Console.WriteLine("Vilken stad vill du ha väder för?");
            var city = Console.ReadLine();

            return city;

        }
    }
}
