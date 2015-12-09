namespace GameOfLife
{
   internal class WorldPoint
   {
      public int X { get; private set; }
      public int Y { get; private set; }

      public WorldPoint(int x, int y)
      {
         X = x;
         Y = y;
      }

      public override bool Equals(object obj)
      {
         var other = obj as WorldPoint;

         return other != null && other.X == X && other.Y == Y;
      }

      public override int GetHashCode()
      {
         int hash = 23;
         hash = hash*31 + X.GetHashCode();
         hash = hash*31 + Y.GetHashCode();
         return hash;
      }

      public override string ToString()
      {
         return string.Format("X: {0} Y: {1}", X, Y);
      }
   }
}
