using System.Collections.Generic;
using System.Linq;
using GameOfLife.Actions;
using GameOfLife.Services;

namespace GameOfLife.Controllers
{
   public class WorldController : IWorldController
   {
      private readonly IWorldActions _worldActions;
      private readonly IWorldPersistenceService _worldPersistenceService;

      public WorldController(IWorldActions worldActions, IWorldPersistenceService worldPersistenceService)
      {
         _worldActions = worldActions;
         _worldPersistenceService = worldPersistenceService;
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

      public void SetGenerations(IEnumerable<World> generationList)
      {
         _worldActions.SetGenerationList(generationList);
      }

      public FileError OpenWorld(string fileName, FileVersion version)
      {
         World world;
         var error = _worldPersistenceService.LoadWorldFromFile(fileName, version, out world);
         if (error != FileError.None)
            return error;

         _worldActions.SetAllCellsDead();
         _worldActions.SetCellsAlive(world.Cells.Select(cell => new WorldPoint(cell.X, cell.Y)).ToArray());

         return FileError.None;
      }

      public FileError SaveWorld(string fileName, FileVersion version, World world)
      {
         return _worldPersistenceService.SaveWorldToFile(fileName, version, world);
      }
   }
}
