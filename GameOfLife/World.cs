using System.Collections.Generic;

namespace GameOfLife
{
   public class World
   {
      public World WithCells(IEnumerable<Cell> cells)
      {
         return new World();
      }
   }
}
