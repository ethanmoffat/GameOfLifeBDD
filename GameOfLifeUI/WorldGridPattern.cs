using System.Collections.Generic;
using System.Windows.Automation.Provider;

namespace GameOfLifeUI
{
   public class WorldGridPattern : IGridProvider, ISelectionProvider
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

      public IRawElementProviderSimple[] GetSelection()
      {
         var ret = new List<IRawElementProviderSimple>();
         for (int row = 0; row < _grid.GridBounds.Height; ++row)
         {
            for (int col = 0; col < _grid.GridBounds.Width; ++col)
            {
               if (_grid[row, col].Activated)
                  ret.Add(_grid[row, col]);
            }
         }
         return ret.ToArray();
      }

      public bool CanSelectMultiple { get { return true; } }
      public bool IsSelectionRequired { get { return false; } }
   }
}
