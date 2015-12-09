namespace GameOfLife
{
   public class Cell
   {
      public int X { get; private set; }
      public int Y { get; private set; }
      public bool IsAlive { get; private set; }

      public Cell(int xLoc, int yLoc, bool isAlive)
      {
         X = xLoc;
         Y = yLoc;
         IsAlive = isAlive;
      }

      public bool IsNeighborOf(Cell originalCell)
      {
         throw new System.NotImplementedException();
      }
   }
}
