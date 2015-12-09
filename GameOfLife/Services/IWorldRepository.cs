using System.Collections.Generic;

namespace GameOfLife.Services
{
   public interface IWorldRepository
   {
      World CurrentWorld { get; set; }

      IReadOnlyList<World> PreviousGenerations { get; set; }
   }

   public interface IWorldProvider
   {
      World CurrentWorld { get; }

      IReadOnlyList<World> PreviousGenerations { get; }
   }

   public interface IWorldUpdater
   {
      World CurrentWorld { set; }

      IReadOnlyList<World> PreviousGenerations { set; }
   }
}
