using System.Collections.Generic;

namespace GameOfLife.Services
{
   public class WorldRepository : IWorldRepository,
                                  IWorldProvider,
                                  IWorldUpdater
   {
      public World CurrentWorld { get; set; }
      public IReadOnlyList<World> PreviousGenerations { get; set; }
   }
}