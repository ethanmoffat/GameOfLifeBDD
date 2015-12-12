using System.Windows.Automation.Provider;

namespace GameOfLifeUI
{
   public class WorldGridPattern : IGridProvider
   {
      private readonly WorldGrid _grid;
      public int RowCount { get { return _grid.GridBounds.Height; } }
      public int ColumnCount { get { return _grid.GridBounds.Width; } }

      public IRawElementProviderSimple GetItem(int row, int column)
      {
         return _grid[row, column];
      }

      public WorldGridPattern(WorldGrid grid)
      {
         _grid = grid;
      }
   }
}
