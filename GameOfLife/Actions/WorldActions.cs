using GameOfLife.Services;

namespace GameOfLife.Actions
{
   public class WorldActions : IWorldActions
   {
      private readonly IWorldRepository _worldRepository;

      public WorldActions(IWorldRepository worldRepository)
      {
         _worldRepository = worldRepository;
      }

      public void SetCellsAlive(params WorldPoint[] points)
      {
         throw new System.NotImplementedException();
      }

      public void SetCellsDead(params WorldPoint[] points)
      {
         throw new System.NotImplementedException();
      }

      public void SetAllCellsDead()
      {
         throw new System.NotImplementedException();
      }

      public World GetNextGenerationFromCurrentWorld()
      {
         throw new System.NotImplementedException();
      }

      public void AddPastGeneration(World pastGenerationOfWorld)
      {
         throw new System.NotImplementedException();
      }
   }
}
