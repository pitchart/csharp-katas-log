namespace GameOfLife
{
    public class GameOfLifeService
    {
        public bool WillCellBeAlive(Cell aliveCell, int aliveNeighborsNumber)
        {
            return !(aliveNeighborsNumber < 2 || aliveNeighborsNumber > 3);
        }
    }
}
