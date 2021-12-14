namespace Tennis.Tennis3
{
    public abstract class ScoreHandler : IScore
    {
        private IScore _score;

        public virtual string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            return _score?.GetScore(playerOneScore, playerTwoScore, playerName);
        }

        public IScore SetNext(IScore score)
        {
            _score = score;

            return score;
        }
    }
}
