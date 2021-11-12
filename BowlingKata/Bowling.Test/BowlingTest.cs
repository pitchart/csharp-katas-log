using System;
using Xunit;

namespace Bowling.Test
{

    public class BowlingTest
    {
        [Fact]
        public void Should_score_zero_when_all_rolls_go_to_the_gutter()
        {
            Bowling game = new Bowling();

            for (int i = 0; i < 20; i++)
                game.Roll(0);

            var score = game.Score();

            Assert.Equal(0, score);
        }
    }

}
