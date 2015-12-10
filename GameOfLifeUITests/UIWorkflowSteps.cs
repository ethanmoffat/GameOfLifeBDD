﻿using System.Collections.ObjectModel;
using GameOfLife;
using GameOfLife.Controllers;
using GameOfLife.Services;
using Moq;
using TechTalk.SpecFlow;

namespace GameOfLifeUITests
{
   [Binding]
   public class UIWorkflowSteps
   {
      private static ISimulationController _simulationController;
      private static IWorldController _worldController;
      private static Mock<IWorldRepository> _worldRepository;
      private static Mock<ISimulationStateRepository> _simulationRepository;

      [BeforeFeature]
      public static void RunBeforeFeature()
      {
         _worldRepository = new Mock<IWorldRepository>();
         _worldRepository.SetupAllProperties();
         _simulationRepository = new Mock<ISimulationStateRepository>();
         _simulationRepository.SetupAllProperties();

         _simulationController = new SimulationController(_simulationRepository.Object);
         _worldController = new WorldController(_worldRepository.Object);
      }

      [Given(@"The simulation is not running")]
      public void GivenTheSimulationIsNotRunning()
      {
         _simulationRepository.Object.CurrentState = SimulationState.Initial;
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

      [When(@"The current generation has no live cells")]
      public void WhenTheCurrentGenerationHasNoLiveCells()
      {
         _worldController.ResetWorldCells();
      }

      [When(@"The previous generation has at least one live cell")]
      public void WhenThePreviousGenerationHasAtLeastOneLiveCell()
      {
         _worldRepository
            .Setup(x => x.PreviousGenerations)
            .Returns(new ReadOnlyCollection<World>(
               new[]
               {
                  new World(new [] { new Cell(1, 1, true) })
               }));
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
   }
}
