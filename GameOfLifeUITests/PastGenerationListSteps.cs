using TechTalk.SpecFlow;

namespace GameOfLifeUITests
{
   [Binding]
   public class PastGenerationListSteps
   {
      [When(@"I select the past generation list entry for generation (.*)")]
      public void WhenISelectThePastGenerationListEntryForGeneration(int p0)
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I select the latest past generation entry")]
      public void WhenISelectTheLatestPastGenerationEntry()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the past generation list is disabled")]
      public void ThenThePastGenerationListIsDisabled()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the past generation list is enabled")]
      public void ThenThePastGenerationListIsEnabled()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the past generation list has no entries")]
      public void ThenThePastGenerationListHasNoEntries()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the past generation list has an entry for generation (.*)")]
      public void ThenThePastGenerationListHasAnEntryForGeneration(int p0)
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"the grid matches the selected past generation list entry")]
      public void ThenTheGridMatchesTheSelectedPastGenerationListEntry()
      {
         ScenarioContext.Current.Pending();
      }
   }
}