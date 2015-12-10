using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLifeUI
{
   public partial class WorldGrid : UserControl
   {
      private readonly Dictionary<Point, WorldGridCell> _gridCells;

      private readonly Pen _gridPen;

      public event EventHandler<GridClickedEventArgs> GridCellClicked;

      public WorldGrid()
      {
         InitializeComponent();

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
      }

      public void UnlockAllCells()
      {
         foreach (var gc in _gridCells.Values)
            gc.EnableEdit();
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

      //protected override void OnResize(EventArgs e)
      //{
      //   base.OnResize(e);
      //}

      private void SetupGridCells()
      {
         foreach (var gc in _gridCells.Values)
            Controls.Remove(gc);
         _gridCells.Clear();

         int numX = Width/17;
         int numY = Height/17;

         for (int row = 0; row <= numY; ++row)
         {
            for (int col = 0; col <= numX; ++col)
            {
               var cell = new WorldGridCell
               {
                  Location = new Point(1+col*17, 1+row*17)
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
