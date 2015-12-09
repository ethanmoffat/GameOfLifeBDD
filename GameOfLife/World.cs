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

      public World GetNextGeneration()
      {
         var mapping = Cells.ToDictionary(cell => new WorldPoint(cell.X, cell.Y));
         var newState = new List<Cell>();

         foreach (var cell in Cells)
         {
            var neighbors = GetNeighborCount(cell, mapping);
            if (cell.IsAlive)
            {
               if (neighbors < 2 || neighbors > 3)
                  newState.Add(cell.AsDead());
               else
                  newState.Add(cell);
            }
            else
            {
               newState.Add(neighbors == 3 ? cell.AsAlive() : cell);
            }
         }

         return new World(newState);
      }

      private int GetNeighborCount(Cell cell)
      {
         throw new System.NotImplementedException();
      }
   }
}
