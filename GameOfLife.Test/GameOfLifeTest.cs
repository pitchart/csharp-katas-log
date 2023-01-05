using Xunit;

namespace GameOfLife.Test
{
    public class GameOfLifeTest
    {
        private readonly GameOfLifeService _gameOfLifeService = new GameOfLifeService();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Should_Die_When_Cell_Has_Less_Than_Two_Living_Neighbors(int aliveNeighborsNumber)
        {
            Cell aliveCell = new Cell { IsAlive = true};
            
            var willBeAlive = _gameOfLifeService.WillCellBeAlive(aliveCell , aliveNeighborsNumber);

            Assert.False(willBeAlive);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Alive_When_Cell_Has_Two_Living_Neighbors(int aliveNeighborsNumber)
        {
            Cell aliveCell = new Cell { IsAlive = true };

            var willBeAlive = _gameOfLifeService.WillCellBeAlive(aliveCell, aliveNeighborsNumber);

            Assert.True(willBeAlive);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(200000)]
        public void Should_Die_When_Cell_Is_Alive_And_Has_More_Than_Three_Neighbors(int aliveNeighborsNumber)
        {
            Cell aliveCell = new Cell { IsAlive= true };

            var willBeAlive = _gameOfLifeService.WillCellBeAlive(aliveCell, aliveNeighborsNumber);

            Assert.False(willBeAlive);
        }

        [Fact]
        public void Should_Be_Alive_When_Cell_Has_Exactly_Three_Alive_Neighbors()
        {
            Cell dieCell = new Cell { IsAlive = false };

            var willBeAlive = _gameOfLifeService.WillCellBeAlive(dieCell, 3);

            Assert.True(willBeAlive);
        }

        [Fact]
        public void Should_Be_Die_When_Cell_Has_Up_Than_Three_Alive_Neighbors()
        {
            Cell dieCell = new Cell { IsAlive = false };

            var willBeAlive = _gameOfLifeService.WillCellBeAlive(dieCell, 4);

            Assert.False(willBeAlive);
        }

        [Fact]
        public void Should_Be_Die_When_Cell_Has_Less_Than_Three_Alive_Neighbors()
        {
            Cell dieCell = new Cell { IsAlive = false };

            var willBeAlive = _gameOfLifeService.WillCellBeAlive(dieCell, 2);

            Assert.False(willBeAlive);
        }
    }
}
