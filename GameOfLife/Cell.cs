namespace GameOfLife
{
    public class Cell
    { 
        public bool IsAlive { get; set; }
    }

    public class AliveCell : Cell
    {
    }
    public class DeadCell : Cell
    {
    }
}
