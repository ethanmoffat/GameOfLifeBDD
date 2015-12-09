using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;

namespace GameOfLifeUITests
{
   [Binding]
   public class UIWorkflowSteps
   {
      private static Application _app;
      private static Window _window;

      [BeforeFeature]
      public static void BeforeEachFeature()
      {
         var directory = Directory.GetCurrentDirectory();
         directory = Path.Combine(directory, "GameOfLife.exe");
         _app = Application.AttachOrLaunch(new ProcessStartInfo(directory));
         _window = _app.GetWindow(GameOfLifeUI.MainForm.TITLE_TEXT, InitializeOption.NoCache);
      }

      [AfterFeature]
      public static void AfterEachFeature()
      {
         if(_app != null)
            _app.Kill();
      }

      [Given(@"I have started the application")]
      public void GivenIHaveStartedTheApplication()
      {
         if (_app == null || _window == null || _window.Title != GameOfLifeUI.MainForm.TITLE_TEXT)
            throw new Exception("The application is not started. Given failed!");
      }

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

      [When(@"I reset the world")]
      public void WhenIResetTheWorld()
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

      [Then(@"The cell is reflected in the display of the world")]
      public void ThenTheCellIsReflectedInTheDisplayOfTheWorld()
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

      [Then(@"The previous generation is displayed")]
      public void ThenThePreviousGenerationIsDisplayed()
      {
         ScenarioContext.Current.Pending();
      }
   }
}
