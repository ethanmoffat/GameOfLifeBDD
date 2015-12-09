using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GameOfLifeTests
{
   [Binding]
   public class WorldRulesSteps
   {
      private World _world;
      private Cell _originalCell;
      private World _nextGeneration;

      [Given(@"a world with a live cell")]
      public void GivenAWorldWithALiveCell()
      {
         _world = new World(new[] { _originalCell = new Cell(1, 1, true) });
      }

      [Given(@"the cell has less than (.*) live neighbors")]
      public void GivenTheCellHasLessThanLiveNeighbors(int liveNeighborExclusiveUpperBound)
      {
         var cell = _world.Cells.Single();
         var neighbors = CreateNeighborList(cell, liveNeighborExclusiveUpperBound - 1);
         _world = _world.WithCells(neighbors);
      }

      [Given(@"the cell has (.*) live neighbors")]
      public void GivenTheCellHasLiveNeighbors(int numberOfLiveNeighbors)
      {
         var cell = _world.Cells.Single();
         var neighbors = CreateNeighborList(cell, numberOfLiveNeighbors);
         _world = _world.WithCells(neighbors);
      }

      [Given(@"the cell has greater than (.*) live neighbors")]
      public void GivenTheCellHasGreaterThanLiveNeighbors(int liveNeighborExclusiveLowerBound)
      {
         var cell = _world.Cells.Single();
         var neighbors = CreateNeighborList(cell, liveNeighborExclusiveLowerBound + 1);
         _world = _world.WithCells(neighbors);
      }

      [Given(@"a world with a dead cell")]
      public void GivenAWorldWithADeadCell()
      {
         _world = new World(new[] { _originalCell = new Cell(1, 1, false) });
      }

      [Given(@"the dead cell does not have exactly (.*) live neighbors")]
      public void GivenTheDeadCellDoesNotHaveExactlyLiveNeighbors(int numberOfLiveNeighbors)
      {
         var cell = _world.Cells.Single();
         var neighbors = CreateNeighborList(cell, numberOfLiveNeighbors + 1);
         _world = _world.WithCells(neighbors);
      }

      [When(@"I get the next generation of the world")]
      public void WhenIGetTheNextGenerationOfTheWorld()
      {
         _nextGeneration = _world.GetNextGeneration();
      }

      [Then(@"the cell should be dead")]
      public void ThenTheCellShouldBeDead()
      {
         var newCell = _nextGeneration.GetCellAt(_originalCell.X, _originalCell.Y);
         Assert.IsFalse(newCell.IsAlive);
      }

      [Then(@"the cell should be alive")]
      public void ThenTheCellShouldBeAlive()
      {
         var newCell = _nextGeneration.GetCellAt(_originalCell.X, _originalCell.Y);
         Assert.IsTrue(newCell.IsAlive);
      }

      private static List<Cell> CreateNeighborList(Cell cell, int numberOfNeighbors)
      {
         var neighbors = new List<Cell>(numberOfNeighbors);

         int ndx = 0;
         for (int y = cell.Y - 1; y <= cell.Y + 1; ++y)
         {
            for (int x = cell.X - 1;
               x <= cell.X + 1 && ndx < numberOfNeighbors;
               ++x, ++ndx)
            {
               if (x == cell.X && y == cell.Y)
                  continue;

               neighbors.Add(new Cell(x, y, true));
            }
         }

         return neighbors;
      }
   }
}
