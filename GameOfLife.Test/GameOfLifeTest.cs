using Xunit;

namespace GameOfLife.Test
{
    public class GameOfLifeTest
    {
        private readonly GameOfLifeService _gameOfLifeService = new GameOfLifeService();

        [Fact]
        public void Should_Die_When_Cell_Has_Less_Than_Two_Living_Neighbors()
        {
            Cell aliveCell = new Cell { IsAlive = true};
            int aliveNeighborsNumber = 1;
            
            var willBeAlive = _gameOfLifeService.WillCellBeAlive(aliveCell , aliveNeighborsNumber);

            Assert.False(willBeAlive);
        }
    }
}
