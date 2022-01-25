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
            Turn turn = new Turn(1);
            turn.Roll(10);

            Assert.True(turn.IsStrike());
        }

        [Fact]
        public void Turn_should_not_be_strike_when_first_roll_is_not_ten()
        {
            Turn turn = new Turn(1);
            turn.Roll(5);

            Assert.False(turn.IsStrike());
        }

        [Fact]
        public void Turn_should_be_complete_when_is_strike()
        {
            Turn turn = new Turn(1);
            turn.Roll(10);

            Assert.True(turn.IsComplete());
        }

        [Fact]
        public void Turn_should_not_be_complete_when_no_rolls()
        {
            Turn turn = new Turn(1);

            Assert.False(turn.IsComplete());
        }

        [Fact]
        public void Turn_should_not_be_complete_when_first_roll_is_not_strike()
        {
            Turn turn = new Turn(1);
            turn.Roll(5);

            Assert.False(turn.IsComplete());
        }

        [Fact]
        public void Turn_should_be_complete_when_two_rolls()
        {
            Turn turn = new Turn(1);
            turn.Roll(5);
            turn.Roll(5);

            Assert.True(turn.IsComplete());
        }

        [Fact]
        public void Turn_should_be_spare_when_sum_of_turn_roll_is_ten()
        {
            Turn turn = new Turn(1);
            turn.Roll(5);
            turn.Roll(5);

            Assert.True(turn.IsSpare());
        }

        [Fact]
        public void Turn_should_not_be_spare_when_is_strike()
        {
            Turn turn = new Turn(1);
            turn.Roll(10);

            Assert.False(turn.IsSpare());
        }

        [Fact]
        public void Turn_score_should_be_sum_of_roll()
        {
            Turn turn = new Turn(1);
            turn.Roll(2);
            turn.Roll(3);

            Assert.Equal(5, turn.GetScore());
        }

        [Fact]
        public void Roll_should_not_allow_when_turn_is_complete()
        {
            Turn turn = new Turn(1);
            turn.Roll(6);
            turn.Roll(3);

            Assert.Throws<NotAllowRollException>(() => turn.Roll(10));
        }

        [Fact]
        public void Last_Turn_should_contain_three_roll_when_have_spare_bonus()
        {
            Turn turn = new Turn(10);
            turn.Roll(6);
            turn.Roll(4);
            turn.Roll(5);

            Assert.Equal(15, turn.GetScore());
        }

        [Fact]
        public void Last_Turn_should_contain_three_roll_when_have_strike_bonus()
        {
            Turn turn = new Turn(10);
            turn.Roll(10);
            turn.Roll(4);
            turn.Roll(5);

            Assert.Equal(19, turn.GetScore());
        }

        [Fact]
        public void Turn_number_should_be_positive()
        {
            Assert.Throws<ArgumentException>(() => new Turn(-1));
        }
    }

    public class NotAllowRollException : Exception
    {
    }

    internal class Turn
    {
        private readonly int _turnNumber;
        List<int> rolls = new List<int>(2);

        public Turn(int turnNumber)
        {
            _turnNumber = turnNumber;
        }

        internal int GetScore()
        {
            return rolls.Sum();
        }

        internal bool IsComplete()
        {
            if (_turnNumber == 10)
            {
                return (IsStrike() || IsSpare()) && rolls.Count == 3 || (!IsStrike() && !IsSpare() && rolls.Count == 2);
            }
            return IsStrike() || rolls.Count == 2;
        }

        internal bool IsSpare()
        {
            return rolls.Sum() == 10 && !IsStrike();
        }

        internal bool IsStrike()
        {
            return rolls.FirstOrDefault() == 10;
        }

        internal void Roll(int pins)
        {
            if (IsComplete())
            {
                throw new NotAllowRollException();
            }

            rolls.Add(pins);
        }
    }
}
