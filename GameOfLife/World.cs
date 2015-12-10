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
         var newCellsList = newCells.ToList();
         var cellList = Cells.ToList();

         var duplicates = cellList.Where(cell => newCellsList.Any(x => cell.X == x.X && cell.Y == x.Y)).ToList();
         foreach (var cell in duplicates)
         {
            cellList.Remove(cell);
            var newCell = newCellsList.Find(x => x.X == cell.X && x.Y == cell.Y);
            cellList.Add(newCell);
            newCellsList.Remove(newCell);
         }

         cellList.AddRange(newCellsList);
         return new World(cellList);
      }

      public World GetNextGeneration()
      {
         var mapping = Cells.ToDictionary(cell => new WorldPoint(cell.X, cell.Y));
         AddMissingDeadNeighbors(mapping);

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

      private void AddMissingDeadNeighbors(Dictionary<WorldPoint, Cell> mapping)
      {
         List<Cell> newCells = new List<Cell>();
         foreach (var kvp in mapping.Where(pair => pair.Value.IsAlive))
         {
            var pt = kvp.Key;
            for (int row = pt.Y - 1; row <= pt.Y + 1; ++row)
            {
               for (int col = pt.X - 1; col <= pt.X + 1; ++col)
               {
                  if (col == pt.X && row == pt.Y) continue;

                  if (!mapping.ContainsKey(new WorldPoint(col, row)) &&
                     !newCells.Any(cell => cell.X == col && cell.Y == row))
                     newCells.Add(new Cell(col, row, false));
               }
            }
         }
         newCells.AddRange(Cells);
         Cells = newCells;
      }

      private int GetLiveNeighborCount(Cell cell, Dictionary<WorldPoint, Cell> mapping)
      {
         int neighborCount = 0;

         for (int row = cell.Y - 1; row <= cell.Y + 1; ++row)
         {
            for (int col = cell.X - 1; col <= cell.X + 1; ++col)
            {
               if (col == cell.X && row == cell.Y) continue;

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
