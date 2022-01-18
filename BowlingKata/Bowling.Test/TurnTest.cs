using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Bowling.Test
{
    public class TurnTest
    {
        [Fact]
        public void Turn_should_be_strike_when_first_roll_is_ten()
        {
            Turn turn = new Turn();
            turn.Roll(10);

            Assert.True(turn.IsStrike());
        }

        [Fact]
        public void Turn_should_not_be_strike_when_first_roll_is_not_ten()
        {
            Turn turn = new Turn();
            turn.Roll(5);

            Assert.False(turn.IsStrike());
        }

        [Fact]
        public void Turn_should_be_complete_when_is_strike()
        {
            Turn turn = new Turn();
            turn.Roll(10);

            Assert.True(turn.IsComplete());
        }

        [Fact]
        public void Turn_should_not_be_complete_when_no_rolls()
        {
            Turn turn = new Turn();

            Assert.False(turn.IsComplete());
        }

        [Fact]
        public void Turn_should_not_be_complete_when_first_roll_is_not_strike()
        {
            Turn turn = new Turn();
            turn.Roll(5);

            Assert.False(turn.IsComplete());
        }

        [Fact]
        public void Turn_should_be_complete_when_two_rolls()
        {
            Turn turn = new Turn();
            turn.Roll(5);
            turn.Roll(5);

            Assert.True(turn.IsComplete());
        }
    }

    internal class Turn
    {
        List<int> rolls = new List<int>(2);

        public Turn()
        {
        }

        internal bool IsComplete()
        {
            return rolls.Any() && IsStrike();
        }

        internal bool IsStrike()
        {
            return rolls.FirstOrDefault() == 10;
        }

        internal void Roll(int pins)
        {
            rolls.Add(pins);
        }
    }
}
