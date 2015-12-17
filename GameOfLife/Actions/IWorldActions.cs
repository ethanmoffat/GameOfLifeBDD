using System.Collections.Generic;

namespace GameOfLife.Actions
{
   public interface IWorldActions
   {
      void CreateDefaultWorld();

      void SetCellsAlive(params WorldPoint[] points);

      void SetCellsDead(params WorldPoint[] points);

      void SetAllCellsDead();

      void IncrementWorldGeneration();

      void SetGenerationList(IEnumerable<World> generationList);
   }
}
