using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLifeUI
{
   public partial class WorldGrid : UserControl
   {
      private enum GridAutomationEventType
      {
         LockAllCells,
         UnlockAllCells,
         ResetAllCells
      }

      private readonly Dictionary<Point, WorldGridCell> _gridCells;

      private readonly Pen _gridPen;
      private Size _originalSize;

      public event EventHandler<GridClickedEventArgs> GridCellClicked;

      public WorldGrid()
      {
         InitializeComponent();

         _originalSize = Size.Empty;

         _gridCells = new Dictionary<Point, WorldGridCell>();
         SetupGridCells();

         _gridPen = new Pen(Color.Black);
      }

      public WorldGridCell this[int row, int col]
      {
         get { return _gridCells[new Point(col, row)]; }
         set { _gridCells[new Point(col, row)] = value; }
      }

      public Rectangle GridBounds
      {
         get { return new Rectangle(0, 0, Width/17, Height/17); }
      }

      public void LockAllCells()
      {
         foreach (var gc in _gridCells.Values)
            gc.DisableEdit();

         FireAutomationEvent(GridAutomationEventType.LockAllCells);
      }

      public void UnlockAllCells()
      {
         foreach (var gc in _gridCells.Values)
            gc.EnableEdit();

         FireAutomationEvent(GridAutomationEventType.UnlockAllCells);
      }

      public void ResetAllCells()
      {
         foreach (var cell in _gridCells.Values.Where(x => x.Activated))
            cell.ToggleActivate();

         FireAutomationEvent(GridAutomationEventType.ResetAllCells);
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         int numX = Width/17;
         int numY = Height/17;

         for (int row = 0; row <= numY; ++row)
         {
            for (int col = 0; col <= numX; ++col)
            {
               e.Graphics.DrawRectangle(_gridPen, new Rectangle(col*17, row*17, 17, 17));
            }
         }

         base.OnPaint(e);
      }

      protected override void OnParentChanged(EventArgs e)
      {
         if (ParentForm != null)
         {
            ParentForm.ResizeBegin += Parent_Resize_Begin;
            ParentForm.ResizeEnd += Parent_Resize_End;
         }
         base.OnParentChanged(e);
      }

      private void Parent_Resize_Begin(object sender, EventArgs e)
      {
         _originalSize = Size;
      }

      private void Parent_Resize_End(object sender, EventArgs e)
      {
         SetupGridCells();
      }

      private void SetupGridCells()
      {
         if (_originalSize.Width >= Size.Width &&
             _originalSize.Height >= Size.Height) return;

         int numX = Width/17 + 1;
         int numY = Height/17 + 1;

         for (int row = 0; row <= numY; ++row)
         {
            for (int col = 0; col <= numX; ++col)
            {
               if (_gridCells.ContainsKey(new Point(col, row)))
                  continue;

               var cell = new WorldGridCell(this, row, col)
               {
                  Location = new Point(1 + col * 17, 1 + row * 17),
                  Name = string.Format("CellAt{0}{1}",row,col)
               };
               cell.Click += CellOnClick;
               _gridCells.Add(new Point(col, row), cell);
            }
         }

         Controls.AddRange(_gridCells.Values.OfType<Control>().ToArray());
      }

      private void CellOnClick(object sender, EventArgs e)
      {
         var cell = (WorldGridCell) sender;
         var coords = _gridCells.FirstOrDefault(x => x.Value == cell).Key;
         var gridEventArgs = new GridClickedEventArgs(coords, cell);
         if (GridCellClicked != null)
            GridCellClicked(this, gridEventArgs);
      }
   }
}
