using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLifeUI
{
   public partial class WorldGridCell : UserControl
   {
      public int Row { get; private set; }
      public int Column { get; private set; }
      private readonly WorldGrid _parentGrid;
      private readonly Point[] _selectorPoints;

      private bool _mouseOver;
      public new bool Enabled { get; private set; }

      private readonly SolidBrush _fillBrush;
      private readonly Pen _selectorPen;

      public bool Activated { get; private set; }

      public WorldGridCell(WorldGrid parentGrid, int row, int col)
      {
         InitializeComponent();

         _parentGrid = parentGrid;
         Row = row;
         Column = col;
         EnableEdit();

         Disposed += OnDisposed;

         _fillBrush = new SolidBrush(Color.Black);

         _selectorPen = new Pen(Color.Black);

         _selectorPoints = new[]
         {
            //top lines
            new Point(Location.X, Location.Y),
            new Point(Location.X + Size.Width/4, Location.Y),
            new Point(Location.X + (Size.Width - Size.Width/4) - 1, Location.Y),
            new Point(Location.X + Size.Width - 1, Location.Y),
            //bot lines
            new Point(Location.X, Location.Y + Size.Height - 1),
            new Point(Location.X + Size.Width/4, Location.Y + Size.Height - 1),
            new Point(Location.X + (Size.Width - Size.Width/4) - 1, Location.Y + Size.Height - 1),
            new Point(Location.X + Size.Width - 1, Location.Y + Size.Height - 1),
            //left lines
            new Point(Location.X, Location.Y),
            new Point(Location.X, Location.Y + Size.Height/4),
            new Point(Location.X, Location.Y + (Size.Height - Size.Height/4) - 1),
            new Point(Location.X, Location.Y + Size.Height),
            //right lines
            new Point(Location.X + Size.Width - 1, Location.Y),
            new Point(Location.X + Size.Width - 1, Location.Y + Size.Height/4),
            new Point(Location.X + Size.Width - 1, Location.Y + (Size.Height - Size.Height/4) - 1),
            new Point(Location.X + Size.Width - 1, Location.Y + Size.Height)
         };
      }

      public void DisableEdit()
      {
         Enabled = false;
      }

      public void EnableEdit()
      {
         Enabled = true;
      }

      public void ToggleActivate()
      {
         Activated = !Activated;
         Invalidate();
      }

      #region Event Overrides

      protected override void OnPaint(PaintEventArgs e)
      {
         DrawFillColor(e);
         DrawSelector(e);
         base.OnPaint(e);
      }

      protected override void OnClick(EventArgs e)
      {
         if (!Enabled)
            return;

         ToggleActivate();
         Invalidate();

         base.OnClick(e);
      }

      protected override void OnMouseEnter(EventArgs e)
      {
         _mouseOver = true;
         Invalidate();
         base.OnMouseEnter(e);
      }

      protected override void OnMouseLeave(EventArgs e)
      {
         _mouseOver = false;
         Invalidate();
         base.OnMouseLeave(e);
      }

      private void OnDisposed(object sender, EventArgs e)
      {
         if (_fillBrush != null)
            _fillBrush.Dispose();
         if (_selectorPen != null)
            _selectorPen.Dispose();
      }

      #endregion

      private void DrawFillColor(PaintEventArgs e)
      {
         if (!Activated) return;

         var area = new Rectangle(new Point(2, 2), new Size(Size.Width - 4, Size.Height - 4));
         e.Graphics.FillRectangle(_fillBrush, area);
      }

      private void DrawSelector(PaintEventArgs e)
      {
         if (!_mouseOver || !Enabled) return;

         for (int i = 0; i < _selectorPoints.Length; i += 2)
            e.Graphics.DrawLines(_selectorPen, new[] {_selectorPoints[i], _selectorPoints[i + 1]});
      }
   }
}
