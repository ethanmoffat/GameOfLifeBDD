using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GameOfLife
{
   public static class WorldSerialize
   {
      public static string SerializeWorldToString(World w)
      {
         StringBuilder sb = new StringBuilder(w.Cells.Count * 7);
         foreach (var cell in w.Cells)
         {
            if (!cell.IsAlive) continue;
            sb.AppendFormat("{0},{1};", cell.X, cell.Y);
         }
         return sb.ToString();
      }

      public static World DeserializeWorldFromString(string s)
      {
         var cellList = s.Split(';')
                         .Where(x => Regex.IsMatch(x, @"\d+\,\d+"))
                         .Select(pair =>
                                 {
                                    var coords = pair.Split(',')
                                                     .Select(int.Parse)
                                                     .ToArray();
                                    return new Cell(coords[0], coords[1], true);
                                 })
                         .ToList();

         return new World(cellList);
      }
   }
}
