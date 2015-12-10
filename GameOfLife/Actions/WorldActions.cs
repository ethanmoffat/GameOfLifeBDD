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

      public void CreateDefaultWorld()
      {
         _worldRepository.CurrentWorld = new World(new List<Cell>());
         _worldRepository.PreviousGenerations = new List<World>(1);
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
         _worldRepository.CurrentWorld = new World(new List<Cell>());
      }

      public void IncrementWorldGeneration()
      {
         var world = _worldRepository.CurrentWorld;
         var newWorld = world.GetNextGeneration();
         _worldRepository.CurrentWorld = newWorld;

         var previousWorlds = new List<World>(_worldRepository.PreviousGenerations) {world};
         _worldRepository.PreviousGenerations = previousWorlds;
      }

      private IEnumerable<WorldPoint> RemoveExistingPoints(World world, IEnumerable<WorldPoint> points)
      {
         return points.Where(pt => !world.Cells.Any(cell => cell.X == pt.X && cell.Y == pt.Y));
      }
   }
}
