namespace GameOfLife
{
    public class GameOfLifeService
    {
        public bool WillCellBeAlive(Cell aliveCell, int aliveNeighborsNumber)
        {
            if (aliveNeighborsNumber == 2)
                return aliveCell.IsAlive;

            if (aliveNeighborsNumber == 3)
                return true;
            else
                return false;
        }

        public Cell GenerateNextCell(Cell cell, int aliveNeighborsNumber)
        {
            return new DeadCell();
        }
    }
}
