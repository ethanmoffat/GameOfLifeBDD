using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GameOfLife;
using GameOfLife.Actions;
using GameOfLife.Controllers;
using GameOfLife.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace GameOfLifeUITests
{
   [Binding]
   public class UIWorkflowSteps
   {
      private static ISimulationController _simulationController;
      private static ISimulationActions _simulationActions;
      private static Mock<ISimulationStateRepository> _simulationRepository;

      private static IWorldController _worldController;
      private static IWorldActions _worldActions;
      private static Mock<IWorldRepository> _worldRepository;

      [BeforeFeature]
      public static void RunBeforeFeature()
      {
         _worldRepository = new Mock<IWorldRepository>();
         _worldRepository.SetupAllProperties();
         _simulationRepository = new Mock<ISimulationStateRepository>();
         _simulationRepository.SetupAllProperties();

         _worldActions = new WorldActions(_worldRepository.Object);
         _simulationActions = new SimulationActions(_simulationRepository.Object);

         _simulationController = new SimulationController(_simulationActions);
         _worldController = new WorldController(_worldActions);
      }

      [Given(@"The simulation is not running")]
      public void GivenTheSimulationIsNotRunning()
      {
         _simulationRepository.Object.CurrentState = SimulationState.Initial;
      }

      [Given(@"I have a world with no cells")]
      public void GivenIHaveAWorldWithNoCells()
      {
         _worldRepository.Object.CurrentWorld = new World(new List<Cell>());
      }

      [Given(@"I have a world that is seeded with at least one live cell")]
      public void GivenIHaveAWorldThatIsSeededWithAtLeastOneLiveCell()
      {
         _worldRepository.Object.CurrentWorld = new World(new[] {new Cell(1, 1, true)});
      }

      [Given(@"The simulation is running")]
      public void GivenTheSimulationIsRunning()
      {
         _simulationRepository.Object.CurrentState = SimulationState.Running;
      }

      [Given(@"The simulation is paused")]
      public void GivenTheSimulationIsPaused()
      {
         _simulationRepository.Object.CurrentState = SimulationState.Paused;
      }

      [When(@"I add a seed cell to the world")]
      public void WhenIAddASeedCellToTheWorld()
      {
         var point = new WorldPoint(2, 2);
         _worldController.SetWorldCellState(new[] { point }, new List<WorldPoint>());
         ScenarioContext.Current.Add("NewCellCoordinates", point);
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
         _worldController.ResetWorldCells();
      }

      [Then(@"The world is seeded with the cell")]
      public void ThenTheWorldIsSeededWithTheCell()
      {
         var point = (WorldPoint) ScenarioContext.Current["NewCellCoordinates"];
         var cell = _worldRepository.Object.CurrentWorld.Cells.Single();

         Assert.IsTrue(cell.IsAlive);
         Assert.AreEqual(point.X, cell.X);
         Assert.AreEqual(point.Y, cell.Y);
      }

      [Then(@"The simulation enters the running state")]
      public void ThenTheSimulationEntersTheRunningState()
      {
         Assert.AreEqual(SimulationState.Running, _simulationRepository.Object.CurrentState);
      }

      [Then(@"The simulation enters the paused state")]
      public void ThenTheSimulationEntersThePausedState()
      {
         Assert.AreEqual(SimulationState.Paused, _simulationRepository.Object.CurrentState);
      }

      [Then(@"The simulation enters the initial state")]
      public void ThenTheSimulationEntersTheInitialState()
      {
         Assert.AreEqual(SimulationState.Initial, _simulationRepository.Object.CurrentState);
      }

      [Then(@"The world has no living cells")]
      public void ThenTheWorldHasNoLivingCells()
      {
         Assert.AreEqual(0, _worldRepository.Object.CurrentWorld.Cells.Count(cell => cell.IsAlive));
      }
   }
}
