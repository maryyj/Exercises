using WeatherApp.Interface;

namespace WeatherAppTests
{
    public class WeatherServiceTests
    {
        [Fact]
        public void GetWeatherWhenCalledReturnsCorrectWeatherDescription()
        {
            //Arrange
            var mockWeatherData = new MockWeatherData();

            var expected = "Raining cat and dogs";

            //Act
            var actual = mockWeatherData.GetWeather();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDateNowWhenCalledReturnsTodaysDayOfWeek()
        {
            //Arrange
            var dateTimeWrapper = new DateTimeWrapper();
            var expected = DateTime.Now.DayOfWeek;
            
            //Act
            var actual = dateTimeWrapper.GetNow().DayOfWeek;

            //Assert
            Assert.Equal(expected,actual);
        }
    }
}