using Manipulator;

namespace StringManipulatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReverseStringWhenCalledReturnsReversedString()
        {
            //Arrange
            var manipulator = new StringManipulator();
            string input = "Hello!";
            var expected = "!olleH";

            //Act
            string actual = manipulator.ReverseString(input);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}