using System;
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

        [Fact]
        public void Turn_number_should_be_equal_or_less_than_ten()
        {
            Assert.Throws<ArgumentException>(() => new Turn(11));
        }

        [Fact]
        public void Pin_number_should_be_positive()
        {
            Turn turn = new Turn(1);
            Assert.Throws<ArgumentException>(() => turn.Roll(-1));
        }

        [Fact]
        public void Pin_number_should_be_equal_or_less_than_ten()
        {
            Turn turn = new Turn(1);
            Assert.Throws<ArgumentException>(() => turn.Roll(11));
        }

        [Fact]
        public void Should_not_have_bonus_when_not_spare_not_strike()
        {
            Turn turn = new Turn(1);
            turn.Roll(4);
            turn.Roll(5);

            Turn secondTurn = new Turn(2);
            secondTurn.Roll(4);
            secondTurn.Roll(5);

            Turn thirdTurn = new Turn(3);
            thirdTurn.Roll(4);
            thirdTurn.Roll(5);

            var score = turn.Bonus(secondTurn, thirdTurn);

            Assert.Equal(0, score);
        }

        [Fact]
        public void Should_have_bonus_for_spare()
        {
            Turn turn = new Turn(1);
            turn.Roll(5);
            turn.Roll(5);

            Turn secondTurn = new Turn(2);
            secondTurn.Roll(4);
            secondTurn.Roll(5);

            Turn thirdTurn = new Turn(3);
            thirdTurn.Roll(4);
            thirdTurn.Roll(5);

            var score = turn.Bonus(secondTurn, thirdTurn);

            Assert.Equal(4, score);
        }
    }
}
