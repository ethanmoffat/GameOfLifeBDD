using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Automation;
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
      private const string LAST_LOCK_KEY = "LastLock";
      private const string CHECK_CELL_KEY = "CheckCell";

      private static Application _app;
      private static Window _window;

      [AfterScenario("FunctionalTest")]
      public static void AfterScenario()
      {
         UnHookGridStatusChangedEvent();

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

         HookGridStatusChangedEvent();
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
         ScenarioContext.Current.Add(CHECK_CELL_KEY, string.Format("CellAt{0}{1}",y,x));
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
         if(deadOrAlive.ToLower() != "alive" && deadOrAlive.ToLower() != "dead")
            throw new ArgumentException("Unexpected value for ThenTheCellShouldDisplayAs. Expected \"dead\" or \"alive\".", deadOrAlive);
         bool shouldBeAlive = deadOrAlive.ToLower() == "alive";

         var cell = _window.Get<ListViewRow>(ScenarioContext.Current[CHECK_CELL_KEY] as string);
         Assert.AreEqual(shouldBeAlive, cell.IsSelected);
      }

      [Then(@"the world should not be editable")]
      public void ThenTheWorldShouldNotBeEditable()
      {
         Assert.AreEqual(WorldGrid.ITEMSTATUS_LOCKED, ScenarioContext.Current[LAST_LOCK_KEY]);
      }

      [Then(@"the world should be editable")]
      public void ThenTheWorldShouldBeEditable()
      {
         Assert.AreEqual(WorldGrid.ITEMSTATUS_UNLOCKED, ScenarioContext.Current[LAST_LOCK_KEY]);
      }

      [Then(@"the world should be reset")]
      public void ThenTheWorldShouldBeReset()
      {
         Assert.IsTrue(ScenarioContext.Current.ContainsKey(WorldGrid.ITEMSTATUS_RESET));
      }

      [Then(@"the simulation should stop when there are no live cells")]
      public void ThenTheSimulationShouldStopWhenThereAreNoLiveCells()
      {
         var reset = _window.Get<Button>("ResetButton");
         var run = _window.Get<Button>("RunButton");
         var resume = _window.Get<Button>("ResumeButton");
         Assert.IsTrue(reset.Enabled);
         Assert.IsTrue(resume.Enabled);
         Assert.IsFalse(run.Enabled);
      }

      private static void ClickCellAt(int x, int y)
      {
         var cell = _window.Get<ListViewRow>(string.Format("CellAt{0}{1}", y, x));
         cell.Select();
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

      private void HookGridStatusChangedEvent()
      {
         var grid = _window.Get<ListView>("WorldGrid");
         Automation.AddAutomationPropertyChangedEventHandler(grid.AutomationElement,
                                                             TreeScope.Element,
                                                             OnGridItemStatusChanged,
                                                             AutomationElementIdentifiers.ItemStatusProperty);
      }

      private static void UnHookGridStatusChangedEvent()
      {
         var grid = _window.Get<ListView>("WorldGrid");
         Automation.RemoveAutomationPropertyChangedEventHandler(grid.AutomationElement, OnGridItemStatusChanged);
      }

      private static void OnGridItemStatusChanged(object sender, AutomationPropertyChangedEventArgs e)
      {
         if (e.Property.Id != AutomationElementIdentifiers.ItemStatusProperty.Id) return;

         switch (e.NewValue as string)
         {
            case WorldGrid.ITEMSTATUS_LOCKED:
            case WorldGrid.ITEMSTATUS_UNLOCKED:
               if (ScenarioContext.Current.ContainsKey(LAST_LOCK_KEY))
                  ScenarioContext.Current[LAST_LOCK_KEY] = e.NewValue;
               else
                  ScenarioContext.Current.Add(LAST_LOCK_KEY, e.NewValue);
               break;
            case WorldGrid.ITEMSTATUS_RESET:
               ScenarioContext.Current.Add(WorldGrid.ITEMSTATUS_RESET, null);
               break;
         }
      }
   }
}
