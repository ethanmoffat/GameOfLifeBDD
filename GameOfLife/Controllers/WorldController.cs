using GameOfLife.Services;

namespace GameOfLife.Controllers
{
   public class WorldController : IWorldController
   {
      private readonly IWorldRepository _worldRepository;

      public WorldController(IWorldRepository worldRepository)
      {
         _worldRepository = worldRepository;
      }

      public void ToggleWorldCellsAtPoints(params WorldPoint[] points)
      {
         throw new System.NotImplementedException();
      }

      public void ResetWorldCells()
      {
         throw new System.NotImplementedException();
      }

      public void CalculateNextGeneration()
      {
         throw new System.NotImplementedException();
      }
   }
}
