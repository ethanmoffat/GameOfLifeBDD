using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GameOfLife
{
   public class World
   {
      public IReadOnlyCollection<Cell> Cells { get; private set; }

      public World(IList<Cell> seed)
      {
         Cells = new ReadOnlyCollection<Cell>(seed);
      }

      public World WithCells(IEnumerable<Cell> cells)
      {
         var cellList = Cells.ToList();
         cellList.AddRange(cells);
         return new World(cellList);
      }
   }
}
