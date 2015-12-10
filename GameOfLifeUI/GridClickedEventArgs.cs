using System;
using System.Drawing;

namespace GameOfLifeUI
{
   public class GridClickedEventArgs : EventArgs
   {
      public Point Location { get; private set; }
      public WorldGridCell Cell { get; private set; }

      public GridClickedEventArgs(Point location, WorldGridCell cell)
      {
         Location = location;
         Cell = cell;
      }
   }
}
