using System.Windows.Automation;
using System.Windows.Automation.Provider;

namespace GameOfLifeUI
{
   public class WorldGridCellPattern : IGridItemProvider, IToggleProvider
   {
      private readonly WorldGridCell _cell;
      private readonly IRawElementProviderSimple _parentGrid;

      public WorldGridCellPattern(WorldGridCell cell, IRawElementProviderSimple parentGrid)
      {
         _cell = cell;
         _parentGrid = parentGrid;
      }

      #region IGridItemProvider

      public int Row { get { return _cell.Row; } }
      public int Column { get { return _cell.Column; } }
      public int RowSpan { get { return 1; } }
      public int ColumnSpan { get { return 1; } }
      public IRawElementProviderSimple ContainingGrid { get { return _parentGrid; } }

      #endregion

      #region IToggleProvider

      public void Toggle()
      {
         _cell.ToggleActivate();
      }

      public ToggleState ToggleState
      {
         get { return _cell.Activated ? ToggleState.On : ToggleState.Off; }
      }

      #endregion
   }
}
