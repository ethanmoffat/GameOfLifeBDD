using System;
using System.Collections.Generic;

namespace GameOfLife
{
   public static class CommonSeedPatterns
   {
      private static readonly Random _gen = new Random();

      public static IEnumerable<WorldPoint> GosperGliderGun
      {
         get
         {
            return new List<WorldPoint>
            {
               new WorldPoint(1, 5),
               new WorldPoint(2, 5),
               new WorldPoint(1, 6),
               new WorldPoint(2, 6),
               new WorldPoint(13, 3),
               new WorldPoint(14, 3),
               new WorldPoint(12, 4),
               new WorldPoint(16, 4),
               new WorldPoint(11, 5),
               new WorldPoint(17, 5),
               new WorldPoint(11, 6),
               new WorldPoint(15, 6),
               new WorldPoint(17, 6),
               new WorldPoint(18, 6),
               new WorldPoint(11, 7),
               new WorldPoint(17, 7),
               new WorldPoint(12, 8),
               new WorldPoint(16, 8),
               new WorldPoint(13, 9),
               new WorldPoint(14, 9),
               new WorldPoint(25, 1),
               new WorldPoint(25, 2),
               new WorldPoint(23, 2),
               new WorldPoint(21, 3),
               new WorldPoint(22, 3),
               new WorldPoint(21, 4),
               new WorldPoint(22, 4),
               new WorldPoint(21, 5),
               new WorldPoint(22, 5),
               new WorldPoint(23, 6),
               new WorldPoint(25, 6),
               new WorldPoint(25, 7),
               new WorldPoint(35, 3),
               new WorldPoint(36, 3),
               new WorldPoint(35, 4),
               new WorldPoint(36, 4)
            };
         }
      }

      public static IEnumerable<WorldPoint> GetRandomPattern(int rows, int cols)
      {
         HashSet<WorldPoint> points = new HashSet<WorldPoint>();
         int numCells = _gen.Next(rows*cols/8, rows*cols/4);
         for (int i = 0; i < numCells; ++i)
         {
            var nextCell = new WorldPoint(_gen.Next(rows), _gen.Next(cols));
            while (points.Contains(nextCell))
               nextCell = new WorldPoint(_gen.Next(rows), _gen.Next(cols));
            points.Add(nextCell);
         }
         return points;
      } 
   }
}
