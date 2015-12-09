using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameOfLife
{
   public class World
   {
      public IReadOnlyCollection<Cell> Cells { get; private set; }

      public World(IList<Cell> seed)
      {
         Cells = new ReadOnlyCollection<Cell>(seed);
      }
   }
}
