using System.Collections.Generic;

namespace GameOfLife.Controllers
{
   public interface IWorldController
   {
      void CreateDefaultWorld();

      void SetWorldCellState(IEnumerable<WorldPoint> alivePoints, IEnumerable<WorldPoint> deadPoints);
      
      void ResetWorldCells();

      void CalculateNextGeneration();

      void SetGenerations(IEnumerable<World> generationList);
   }
}
