using Xunit;

namespace Tennis.Tests
{

    public class Tennis2Tests : TennisTestCases
    {
        public Tennis2Tests() : base(new TennisGame2("player1", "player2"))
        {}
    }
}
