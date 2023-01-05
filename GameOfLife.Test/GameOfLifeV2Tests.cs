using Xunit;

namespace GameOfLife.Test
{
    public class GameOfLifeV2Tests
    {
        private readonly GameOfLifeService _gameOfLifeService = new GameOfLifeService();

        [Fact]
        public void Should_Kill_Cell_When_Over_Population()
        {
            Cell cell = new AliveCell();

            Cell actual = _gameOfLifeService.GenerateNextCell(cell, 4);

            Assert.IsType<DeadCell>(actual);
        }

        [Fact]
        public void Should_Kill_Cell_When_Under_Population()
        {
            Cell cell = new AliveCell();

            Cell actual = _gameOfLifeService.GenerateNextCell(cell, 1);

            Assert.IsType<DeadCell>(actual);
        }

        [Fact]
        public void Should_Alive_When_Cell_Has_Only_Three_Neighbors()
        {
            Cell cell = new DeadCell();

            Cell actual = _gameOfLifeService.GenerateNextCell(cell, 3);

            Assert.IsType<AliveCell>(actual);
        }
    }
}
