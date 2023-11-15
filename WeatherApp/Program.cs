using WeatherApp.Interface;

namespace WeatherApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var dateTimeWrapper = new DateTimeWrapper();
            var weatherService = new WeatherService(dateTimeWrapper);

            string city = weatherService.GetCityFromUser();
            var weather = weatherData.GetWeather();
            weatherService.GenerateOutputString(city, weather);
        }
    }
}