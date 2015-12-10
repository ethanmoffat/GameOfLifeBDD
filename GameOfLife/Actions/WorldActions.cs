using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
         var world = _worldRepository.CurrentWorld;
         _worldRepository.CurrentWorld = world.WithCells(RemoveExistingPoints(world, points).Select(pt => new Cell(pt.X, pt.Y, true)));
      }

      public void SetCellsDead(params WorldPoint[] points)
      {
         var world = _worldRepository.CurrentWorld;
         _worldRepository.CurrentWorld = world.WithCells(RemoveExistingPoints(world, points).Select(pt => new Cell(pt.X, pt.Y, false)));
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

      private IEnumerable<WorldPoint> RemoveExistingPoints(World world, IEnumerable<WorldPoint> points)
      {
         return points.Where(pt => !world.Cells.Any(cell => cell.X == pt.X && cell.Y == pt.Y));
      }
   }
}
