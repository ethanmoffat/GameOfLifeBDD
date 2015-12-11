using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using GameOfLifeUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems;
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
      public void GivenIHaveAWorldWithALiveCellAtDisplayed(int x, int y)
      {
         ClickCellAt(x, y);
      }

      [Given(@"the simulation has started")]
      public void GivenTheSimulationHasStarted()
      {
         RunSimulation();
      }

      [Given(@"the simulation has been paused")]
      public void GivenTheSimulationHasBeenPaused()
      {
         PauseSimulation();
      }

      [When(@"I select the cell at (.*), (.*)")]
      public void WhenISelectTheCellAt(int x, int y)
      {
         ClickCellAt(x, y);
      }

      [When(@"I run the simulation in the ui")]
      public void WhenIRunTheSimulationInTheUi()
      {
         RunSimulation();
      }

      [When(@"I pause the simulation in the ui")]
      public void WhenIPauseTheSimulationInTheUi()
      {
         PauseSimulation();
      }

      [When(@"I resume the simulation in the ui")]
      public void WhenIResumeTheSimulationInTheUi()
      {
         ResumeSimulation();
      }

      [When(@"I reset the simulation in the ui")]
      public void WhenIResetTheSimulationInTheUi()
      {
         ResetSimulation();
      }

      [When(@"I let the simulation run")]
      public void WhenILetTheSimulationRun()
      {
         //Would be nice to have a better method of waiting...this works for now
         Thread.Sleep(1000);
      }

      [Then(@"the cell should display as ""(.*)""")]
      public void ThenTheCellShouldDisplayAs(string deadOrAlive)
      {
         //this is where we need the grid provider...
         //bool alive = deadOrAlive.ToLower() == "alive";
         //bool dead = deadOrAlive.ToLower() == "dead";

         //_window.???

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
         //there should be a better way to check this, instead of observing enabled state
         //also, it throws an exception when getting a button that is not Visible
         var reset = _window.Get<Button>("ResetButton");
         var run = _window.Get<Button>("RunButton");
         var resume = _window.Get<Button>("ResumeButton");
         Assert.IsTrue(reset.Enabled);
         Assert.IsTrue(resume.Enabled);
         Assert.IsFalse(run.Enabled);
      }

      private static void ClickCellAt(int x, int y)
      {
         //would love to have a provider for the custom grid, but manually clicking it seems to work fine
         var topRight = _window.Location;
         topRight = new Point(topRight.X + 25, topRight.Y + 46);
         _window.Mouse.Location = new Point(topRight.X + x * 17, topRight.Y + y * 17);
         _window.Mouse.Click();
      }

      private static void RunSimulation()
      {
         var run = _window.Get<Button>("RunButton");
         run.Click();
      }

      private static void PauseSimulation()
      {
         var pause = _window.Get<Button>("PauseButton");
         pause.Click();
      }

      private static void ResumeSimulation()
      {
         var run = _window.Get<Button>("ResumeButton");
         run.Click();
      }

      private static void ResetSimulation()
      {
         var pause = _window.Get<Button>("ResetButton");
         pause.Click();
      }
   }
}
