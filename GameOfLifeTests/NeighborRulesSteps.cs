using System;
using TechTalk.SpecFlow;

namespace GameOfLifeTests
{
    [Binding]
    public class NeighborRulesSteps
    {
        [Given(@"I have a cell with x = (.*) and y = (.*)")]
        public void GivenIHaveACellWithXAndY(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have a different cell with x = (.*) and y = (.*)")]
        public void GivenIHaveADifferentCellWithXAndY(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I check if the cells are neighbors")]
        public void WhenICheckIfTheCellsAreNeighbors()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"An error indicates the two cells are the same cell")]
        public void ThenAnErrorIndicatesTheTwoCellsAreTheSameCell()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The two cells are neighbor cells")]
        public void ThenTheTwoCellsAreNeighborCells()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The two cells are not neighbor cells")]
        public void ThenTheTwoCellsAreNotNeighborCells()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
