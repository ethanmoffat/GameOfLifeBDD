using System;
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

      public World WithCells(IEnumerable<Cell> newCells)
      {
         var newCellsList = newCells as IList<Cell> ?? newCells.ToList();
         if(Cells.Any(existing => newCellsList.Any(newCell => newCell.X == existing.X && newCell.Y == existing.Y)))
            throw new ArgumentException("A duplicate cell exists in the new list of cells.", "newCells");

         var cellList = Cells.ToList();
         cellList.AddRange(newCellsList);
         return new World(cellList);
      }

      public World GetNextGeneration()
      {
         var mapping = Cells.ToDictionary(cell => new WorldPoint(cell.X, cell.Y));
         var newState = new List<Cell>();

         foreach (var cell in Cells)
         {
            var neighbors = GetLiveNeighborCount(cell, mapping);
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

      private int GetLiveNeighborCount(Cell cell, Dictionary<WorldPoint, Cell> mapping)
      {
         int neighborCount = 0;

         for (int row = cell.Y - 1; row <= cell.Y + 1; ++row)
         {
            for (int col = cell.X - 1; col <= cell.X + 1; ++col)
            {
               if (row == cell.X && col == cell.Y) continue;

               var pt = new WorldPoint(col, row);
               if (mapping.ContainsKey(pt) && mapping[pt].IsAlive)
                  neighborCount++;
            }
         }

         return neighborCount;
      }

      public Cell GetCellAt(int xCoord, int yCoord)
      {
         return Cells.SingleOrDefault(cell => cell.X == xCoord && cell.Y == yCoord);
      }
   }
}
