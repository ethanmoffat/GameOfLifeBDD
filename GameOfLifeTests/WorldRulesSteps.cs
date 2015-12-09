using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using TechTalk.SpecFlow;

namespace GameOfLifeTests
{
   [Binding]
   public class WorldRulesSteps
   {
      private World _world;

      [Given(@"a world with a live cell")]
      public void GivenAWorldWithALiveCell()
      {
         _world = new World(new[] {new Cell(1, 1, true)});
      }

      [Given(@"the cell has less than (.*) live neighbors")]
      public void GivenTheCellHasLessThanLiveNeighbors(int liveNeighborUpperBound)
      {
         var cell = _world.Cells.Single();

         var neighbors = new List<Cell>(liveNeighborUpperBound);

         for (int y = cell.Y - 1; y <= cell.Y + 1; ++y)
         {
            for (int x = cell.X - 1, ndx = 0;
               x <= cell.X + 1 && ndx < liveNeighborUpperBound;
               ++x, ++ndx)
            {
               neighbors.Add(new Cell(x, y, true));
            }
         }

         _world = _world.WithCells(neighbors);
      }

      [Given(@"the cell has (.*) live neighbors")]
      public void GivenTheCellHasLiveNeighbors(int numberOfLiveNeighbors)
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"the cell has greater than (.*) live neighbors")]
      public void GivenTheCellHasGreaterThanLiveNeighbors(int liveNeighborLowerBound)
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"a world with a dead cell")]
      public void GivenAWorldWithADeadCell()
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"the dead cell does not have exactly (.*) live neighbors")]
      public void GivenTheDeadCellDoesNotHaveExactlyLiveNeighbors(int numberOfLiveNeighbors)
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I get the next generation of the world")]
      public void WhenIGetTheNextGenerationOfTheWorld()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the cell should be dead")]
      public void ThenTheCellShouldBeDead()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the cell should be alive")]
      public void ThenTheCellShouldBeAlive()
      {
         ScenarioContext.Current.Pending();
      }
   }
}
