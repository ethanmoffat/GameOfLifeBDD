using System;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GameOfLifeTests
{
    [Binding]
    public class NeighborRulesSteps
    {
       private Cell _originalCell;
       private Cell _differentCell;

       private bool _isNeighborOf_result, _isNeighborOf_result2;

        [Given(@"I have a cell with x = (.*) and y = (.*)")]
        public void GivenIHaveACellWithXAndY(int xCoordinate, int yCoordinate)
        {
           _originalCell = new Cell(xCoordinate, yCoordinate, false);
        }
        
        [Given(@"I have a different cell with x = (.*) and y = (.*)")]
        public void GivenIHaveADifferentCellWithXAndY(int xCoordinate, int yCoordinate)
        {
           _differentCell = new Cell(xCoordinate, yCoordinate, false);
        }
        
        [When(@"I check if the cells are neighbors")]
        public void WhenICheckIfTheCellsAreNeighbors()
        {
           try
           {
              _isNeighborOf_result = _differentCell.IsNeighborOf(_originalCell);
           }
           catch (NotImplementedException)
           {
              throw;
           }
           catch (Exception ex)
           {
              ScenarioContext.Current.Add("_isNeighborOfRes", ex);
           }

           try
           {
              _isNeighborOf_result2 = _originalCell.IsNeighborOf(_differentCell);
           }
           catch (NotImplementedException)
           {
              throw;
           }
           catch (Exception ex)
           {
              ScenarioContext.Current.Add("_isNeighborOfRes2", ex);
           }
        }
        
        [Then(@"An error indicates the two cells are the same cell")]
        public void ThenAnErrorIndicatesTheTwoCellsAreTheSameCell()
        {
           Assert.IsNotNull(ScenarioContext.Current["_isNeighborOfRes"]);
           Assert.IsNotNull(ScenarioContext.Current["_isNeighborOfRes2"]);
        }
        
        [Then(@"The two cells are neighbor cells")]
        public void ThenTheTwoCellsAreNeighborCells()
        {
           Assert.IsTrue(_isNeighborOf_result);
           Assert.IsTrue(_isNeighborOf_result2);
        }
        
        [Then(@"The two cells are not neighbor cells")]
        public void ThenTheTwoCellsAreNotNeighborCells()
        {
           Assert.IsFalse(_isNeighborOf_result);
           Assert.IsFalse(_isNeighborOf_result2);
        }
    }
}
