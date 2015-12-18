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

      FileError OpenWorld(string fileName, FileVersion version);

      FileError SaveWorld(string fileName, FileVersion version, World world);
   }
}
