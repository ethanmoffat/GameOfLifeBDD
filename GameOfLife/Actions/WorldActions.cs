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
         _worldRepository.CurrentWorld = world.WithCells(points.Select(pt => new Cell(pt.X, pt.Y, true)));
      }

      public void SetCellsDead(params WorldPoint[] points)
      {
         var world = _worldRepository.CurrentWorld;
         _worldRepository.CurrentWorld = world.WithCells(points.Select(pt => new Cell(pt.X, pt.Y, false)));
      }

      public void SetAllCellsDead()
      {
         var cellsAsDead = _worldRepository.CurrentWorld.Cells.Select(x => x.AsDead());
         _worldRepository.CurrentWorld = _worldRepository.CurrentWorld.WithCells(cellsAsDead);
      }

      public void IncrementWorldGeneration()
      {
         var world = _worldRepository.CurrentWorld;
         var newWorld = world.GetNextGeneration();
         _worldRepository.CurrentWorld = newWorld;

         var previousWorlds = new List<World>(_worldRepository.PreviousGenerations) { world };
         _worldRepository.PreviousGenerations = previousWorlds;
      }

      public void SetGenerationList(IEnumerable<World> generationList)
      {
         _worldRepository.PreviousGenerations = generationList as List<World> ?? generationList.ToList();
         if (_worldRepository.PreviousGenerations.Count > 0)
            _worldRepository.CurrentWorld = _worldRepository.PreviousGenerations.Last().GetNextGeneration();
      }
   }
}
