using System.Windows.Automation;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace GameOfLifeUITests
{
   [Binding]
   public class PastGenerationListSteps
   {
      private const string GENERATION_LIST_NAME = "GenerationList";
      
      [AfterScenario("FunctionalTest")]
      public static void AfterScenario()
      {
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         Automation.RemoveAutomationEventHandler(SelectionItemPattern.ElementSelectedEvent,
                                                 list.AutomationElement,
                                                 OnGenerationSelected);
      }

      private static void OnGenerationSelected(object sender, AutomationEventArgs e)
      {
         if (e.EventId.Id != SelectionItemPattern.ElementSelectedEvent.Id)
            return;

         //NOTE: This returns the automation element in sender. How to get the underlying data value???
         //var world = sender as World;
      }

      [When(@"I select the past generation list entry for generation (.*)")]
      public void WhenISelectThePastGenerationListEntryForGeneration(int generationNumber)
      {
         //NOTE: Only needed for the OnGenerationSelected event
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         Automation.AddAutomationEventHandler(SelectionItemPattern.ElementSelectedEvent,
                                              list.AutomationElement,
                                              TreeScope.Subtree,
                                              OnGenerationSelected);

         //var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         list.Select(generationNumber);
      }

      [When(@"I select the latest past generation entry")]
      public void WhenISelectTheLatestPastGenerationEntry()
      {
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         list.Select(list.Items.Count - 1);
      }

      [Then(@"the past generation list is disabled")]
      public void ThenThePastGenerationListIsDisabled()
      {
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         Assert.IsFalse(list.Enabled);
      }

      [Then(@"the past generation list is enabled")]
      public void ThenThePastGenerationListIsEnabled()
      {
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         Assert.IsTrue(list.Enabled);
      }

      [Then(@"the past generation list has no entries")]
      public void ThenThePastGenerationListHasNoEntries()
      {
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         Assert.AreEqual(0, list.Items.Count);
      }

      [Then(@"the past generation list has an entry for generation (.*)")]
      public void ThenThePastGenerationListHasAnEntryForGeneration(int generationNumber)
      {
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         Assert.IsNotNull(list.Items[generationNumber]);
      }

      [Then(@"the grid matches the selected past generation list entry")]
      public void ThenTheGridMatchesTheSelectedPastGenerationListEntry()
      {
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         var grid = WorldGridSteps.Window.Get<ListView>("WorldGrid");

         ScenarioContext.Current.Pending();

         //TODO: How to compare grid values with data contained in the list box?
         //var selectedWorld = list.SelectedItem.
      }
   }
}