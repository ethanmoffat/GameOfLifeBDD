using System.Collections.Generic;
using System.Windows.Automation;
using System.Windows.Automation.Provider;

namespace GameOfLifeUI
{
   public class WorldGridProvider : ISelectionProvider, ITableProvider
   {
      private readonly WorldGrid _grid;

      public WorldGridProvider(WorldGrid grid)
      {
         _grid = grid;
      }

      #region IGridProvider

      public int RowCount { get { return _grid.GridBounds.Height; } }
      public int ColumnCount { get { return _grid.GridBounds.Width; } }

      public IRawElementProviderSimple GetItem(int row, int column)
      {
         return _grid[row, column];
      }

      #endregion

      #region ISelectionProvider

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

      #endregion

      #region ITableProvider

      public IRawElementProviderSimple[] GetRowHeaders()
      {
         return null;
      }

      public IRawElementProviderSimple[] GetColumnHeaders()
      {
         return null;
      }

      public RowOrColumnMajor RowOrColumnMajor { get { return RowOrColumnMajor.Indeterminate; } }

      #endregion
   }
}
