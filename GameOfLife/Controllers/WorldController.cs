using System.Collections.Generic;
using System.Linq;
using GameOfLife.Actions;

namespace GameOfLife.Controllers
{
   public class WorldController : IWorldController
   {
      private readonly IWorldActions _worldActions;

      public WorldController(IWorldActions worldActions)
      {
         _worldActions = worldActions;
      }

      public void CreateDefaultWorld()
      {
         _worldActions.CreateDefaultWorld();
      }

      public void SetWorldCellState(IEnumerable<WorldPoint> alivePoints, IEnumerable<WorldPoint> deadPoints)
      {
         _worldActions.SetCellsAlive(alivePoints.ToArray());
         _worldActions.SetCellsDead(deadPoints.ToArray());
      }

      public void ResetWorldCells()
      {
         _worldActions.SetAllCellsDead();
      }

      public void CalculateNextGeneration()
      {
         _worldActions.IncrementWorldGeneration();
      }
   }
}
