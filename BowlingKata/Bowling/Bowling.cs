namespace Bowling
{
    public class Bowling
    {
        private readonly Turn _firstTurn;

        public Bowling()
        {
            _firstTurn = Turn.Build(10);
        }

        public void Roll(int fallenPins)
        {
            _firstTurn.Roll(fallenPins);
        }

        public int GetScore()
        {
            return _firstTurn.GetTotalScore();
        }
    }
}
