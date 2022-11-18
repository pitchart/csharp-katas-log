using Theater.Test.Tooling;
using Xunit;

namespace Theater.Test.Acceptance
{

    public class SeatSuggestionTest
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var theater = TheaterBuilder.ADefaultTheater()
                .Build();
            var finder = new SeatFinder(theater);

            // Act
            var suggestion = finder.Suggest(3);

            // Assert
        }
    }

}
