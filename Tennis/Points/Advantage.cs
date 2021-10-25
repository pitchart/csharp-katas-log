namespace Tennis.Points
{

    public class Advantage : IPoint
    {
        private Player _player;
        public Advantage(Player player)
        {
            _player = player;
        }

        public string GetScore(string name)
        {
            return $"Advantage {name}";
        }

        public IPoint ScoreP1(){
            if (_player ==  Player.Pé1){
                return new Win(_player);
            }

            return new Deuce();
        }

        public IPoint ScoreP2()
        {
            if (_player == Player.Pé1)
            {
                return new Deuce();
            }

            return new Win(_player);
        }
    }

}
