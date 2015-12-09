using System.Collections.Generic;
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
         ScenarioContext.Current.Pending();
      }

      [Given(@"the cell has (.*) live neighbors")]
      public void GivenTheCellHasLiveNeighbors(int p0)
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"the cell has greater than (.*) live neighbors")]
      public void GivenTheCellHasGreaterThanLiveNeighbors(int p0)
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"a world with a dead cell")]
      public void GivenAWorldWithADeadCell()
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"the dead cell does not have exactly (.*) live neighbors")]
      public void GivenTheDeadCellDoesNotHaveExactlyLiveNeighbors(int p0)
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
