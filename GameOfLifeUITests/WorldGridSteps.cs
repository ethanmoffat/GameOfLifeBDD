using System.Diagnostics;
using System.IO;
using System.Threading;
using GameOfLifeUI;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace GameOfLifeUITests
{
   [Binding]
   public class WorldGridSteps
   {
      private static Application _app;
      private static Window _window;

      [AfterScenario]
      public static void AfterScenario()
      {
         Thread.Sleep(1000);
         if (_app != null)
            _app.Kill();
      }

      [Given(@"The application has started")]
      public void GivenTheApplicationHasStarted()
      {
         //runs at beginning of each scenario
         var currentDir = Directory.GetCurrentDirectory();

         _app = Application.AttachOrLaunch(new ProcessStartInfo(Path.Combine(currentDir, "GameOfLifeUI.exe")));
         _window = _app.GetWindow(MainForm.TITLE_TEXT);
      }

      [Given(@"I have a world with a live cell at (.*), (.*) displayed")]
      public void GivenIHaveAWorldWithALiveCellAtDisplayed(int p0, int p1)
      {
         //_window.Get<>()
      }

      [Given(@"the simulation has started")]
      public void GivenTheSimulationHasStarted()
      {
         ScenarioContext.Current.Pending();
      }

      [Given(@"the simulation has been paused")]
      public void GivenTheSimulationHasBeenPaused()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I select the cell at (.*), (.*)")]
      public void WhenISelectTheCellAt(int p0, int p1)
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I run the simulation in the ui")]
      public void WhenIRunTheSimulationInTheUi()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I pause the simulation in the ui")]
      public void WhenIPauseTheSimulationInTheUi()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I resume the simulation in the ui")]
      public void WhenIResumeTheSimulationInTheUi()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I reset the simulation in the ui")]
      public void WhenIResetTheSimulationInTheUi()
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I let the simulation run")]
      public void WhenILetTheSimulationRun()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the cell should display as ""(.*)""")]
      public void ThenTheCellShouldDisplayAs(string p0)
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the world should not be editable")]
      public void ThenTheWorldShouldNotBeEditable()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the world should be editable")]
      public void ThenTheWorldShouldBeEditable()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the world should be reset")]
      public void ThenTheWorldShouldBeReset()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the simulation should stop when there are no live cells")]
      public void ThenTheSimulationShouldStopWhenThereAreNoLiveCells()
      {
         ScenarioContext.Current.Pending();
      }
   }
}
