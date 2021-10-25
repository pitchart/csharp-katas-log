using System;

namespace Tennis.Points
{

    public class Win : IPoint
    {
        private readonly Player _player;

        public Win(Player player)
        {
            _player = player;
        }

        public string GetScore(string name)
        {
            return $"Win for {name}";
        }

        public IPoint ScoreP1()
        {
            throw new Exception("Party is over! Winner is "+ nameof(_player));
        }

        public IPoint ScoreP2()
        {
            throw new Exception("Party is over! Winner is "+ nameof(_player));
        }
    }

}
