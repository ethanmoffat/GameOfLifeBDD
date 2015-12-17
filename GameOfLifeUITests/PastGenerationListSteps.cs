using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using GameOfLife;
using GameOfLifeUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace GameOfLifeUITests
{
   [Binding]
   public class PastGenerationListSteps
   {
      private const string SELECTED_WORLD_KEY = "SelectedWorld";
      private const string GENERATION_LIST_NAME = "GenerationList";

      [When(@"I select the past generation list entry for generation (.*)")]
      public void WhenISelectThePastGenerationListEntryForGeneration(int generationNumber)
      {
         var list = WorldGridSteps.Window.Get<ListBox>(GENERATION_LIST_NAME);
         var item = list.Items[generationNumber];
         item.Click();
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
         var expectedWorld = GetWorldFromMappedMemory();

         var actualCells = GetWorldFromGridDisplay().Cells.ToList();
         foreach (var expectedCell in expectedWorld.Cells)
         {
            Assert.IsNotNull(actualCells.Single(actualCell => actualCell.IsAlive && 
                                                              actualCell.X == expectedCell.X && 
                                                              actualCell.Y == expectedCell.Y));
         }
      }

      private static World GetWorldFromGridDisplay()
      {
         var grid = WorldGridSteps.Window.Get<ListView>("WorldGrid");

         var selected = grid.SelectedRows;
         var activeCells = selected.Select(x =>
         {
            var simpleName = x.Name.Replace("Grid Cell ", "")
                                   .Replace(", ", "x");
            var coords = simpleName.Split('x')
                                   .Select(int.Parse)
                                   .ToArray();
            return new Cell(coords[0], coords[1], true);
         }).ToList();

         return new World(activeCells);
      }

      private static World GetWorldFromMappedMemory()
      {
         string str;

         using (var mut = Mutex.OpenExisting(PastGenerationListBox.SELECTEDWORLD_MUTEX_NAME))
         {
            mut.WaitOne();

            using (var sharedMem = MemoryMappedFile.OpenExisting(PastGenerationListBox.SELECTEDWORLD_MEMORY_NAME))
            {
               using (var stream = sharedMem.CreateViewStream())
               {
                  byte[] rawLen = new byte[4];
                  stream.Read(rawLen, 0, 4);
                  var len = BitConverter.ToInt32(rawLen, 0);

                  byte[] rawData = new byte[len];
                  stream.Read(rawData, 0, rawData.Length);
                  str = Encoding.ASCII.GetString(rawData);
               }
            }

            mut.ReleaseMutex();
         }

         return WorldSerialize.DeserializeWorldFromString(str);
      }
   }
}