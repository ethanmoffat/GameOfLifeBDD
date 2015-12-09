using System;

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

      public bool IsNeighborOf(Cell neighborCell)
      {
         if(this == neighborCell || (X == neighborCell.X && Y == neighborCell.Y))
            throw new ArgumentException("The two cells are the same", "neighborCell");

         var xDif = Math.Abs(X - neighborCell.X);
         var yDif = Math.Abs(Y - neighborCell.Y);

         return (xDif == 1 && yDif == 1) || (xDif ^ yDif) == 1;
      }
   }
}
