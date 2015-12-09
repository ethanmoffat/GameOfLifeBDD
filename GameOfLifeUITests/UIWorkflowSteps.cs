using System;
using TechTalk.SpecFlow;

namespace GameOfLifeUITests
{
   [Binding]
   public class UIWorkflowSteps
   {
      [Given(@"The simulation is not running")]
      public void GivenTheSimulationIsNotRunning()
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"I have a world that is seeded with at least one live cell")]
      public void GivenIHaveAWorldThatIsSeededWithAtLeastOneLiveCell()
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"The simulation is running")]
      public void GivenTheSimulationIsRunning()
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"The simulation is paused")]
      public void GivenTheSimulationIsPaused()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I add a seed cell to the world")]
      public void WhenIAddASeedCellToTheWorld()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I run the game of life simulation")]
      public void WhenIRunTheGameOfLifeSimulation()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I pause the simulation")]
      public void WhenIPauseTheSimulation()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I resume the simulation")]
      public void WhenIResumeTheSimulation()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I reset the simulation")]
      public void WhenIResetTheSimulation()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I select a previous world generation")]
      public void WhenISelectAPreviousWorldGeneration()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"The current generation has no live cells")]
      public void WhenTheCurrentGenerationHasNoLiveCells()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"The previous generation has at least one live cell")]
      public void WhenThePreviousGenerationHasAtLeastOneLiveCell()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"The world is seeded with the cell")]
      public void ThenTheWorldIsSeededWithTheCell()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"The simulation enters the running state")]
      public void ThenTheSimulationEntersTheRunningState()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"The simulation enters the paused state")]
      public void ThenTheSimulationEntersThePausedState()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"The simulation enters the initial state")]
      public void ThenTheSimulationEntersTheInitialState()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"The world is set to the initial state")]
      public void ThenTheWorldIsSetToTheInitialState()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"The previous world generation is shown")]
      public void ThenThePreviousWorldGenerationIsShown()
      {
         ScenarioContext.Current.Pending();
      }
   }
}
