using GameOfLife;
using GameOfLife.Controllers;
using TechTalk.SpecFlow;

namespace GameOfLifeUITests
{
   [Binding]
   public class UIWorkflowSteps
   {
      private static ISimulationController _simulationController;
      private static IWorldController _worldController;

      [BeforeFeature]
      public static void RunBeforeFeature()
      {
         //_simulationController = new SimulationController();
         //_worldController = new WorldController();
      }

      [Given(@"The simulation is not running")]
      public void GivenTheSimulationIsNotRunning()
      {
         _simulationController.ResetSimulation();
      }

      [Given(@"I have a world that is seeded with at least one live cell")]
      public void GivenIHaveAWorldThatIsSeededWithAtLeastOneLiveCell()
      {
         _worldController.ToggleWorldCellsAtPoints(new WorldPoint(1, 1));
      }

      [Given(@"The simulation is running")]
      public void GivenTheSimulationIsRunning()
      {
         _simulationController.RunSimulation();
      }

      [Given(@"The simulation is paused")]
      public void GivenTheSimulationIsPaused()
      {
         _simulationController.PauseSimulation();
      }

      [When(@"I add a seed cell to the world")]
      public void WhenIAddASeedCellToTheWorld()
      {
         _worldController.ToggleWorldCellsAtPoints(new WorldPoint(2, 2));
      }

      [When(@"I run the game of life simulation")]
      public void WhenIRunTheGameOfLifeSimulation()
      {
         _simulationController.RunSimulation();
      }

      [When(@"I pause the simulation")]
      public void WhenIPauseTheSimulation()
      {
         _simulationController.PauseSimulation();
      }

      [When(@"I resume the simulation")]
      public void WhenIResumeTheSimulation()
      {
         _simulationController.ResumeSimulation();
      }

      [When(@"I reset the simulation")]
      public void WhenIResetTheSimulation()
      {
         _simulationController.ResetSimulation();
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
