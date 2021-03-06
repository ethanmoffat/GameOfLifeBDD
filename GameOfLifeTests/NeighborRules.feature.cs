﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace GameOfLifeTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class NeighborRulesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NeighborRules.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "NeighborRules", " In order to simulate the game of life\n As a pretty cool guy who doesn\'t afraid o" +
                    "f anything\n I want to know how a neighbor is defined in a World", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "NeighborRules")))
            {
                GameOfLifeTests.NeighborRulesFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cells with the same coordinates have an error")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NeighborRules")]
        public virtual void CellsWithTheSameCoordinatesHaveAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cells with the same coordinates have an error", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
   testRunner.Given("I have a cell with x = 1 and y = 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
   testRunner.Given("I have a different cell with x = 1 and y = 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
   testRunner.When("I check if the cells are neighbors", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
   testRunner.Then("An error indicates the two cells are the same cell", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Diagonal cells are neighbors")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NeighborRules")]
        public virtual void DiagonalCellsAreNeighbors()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Diagonal cells are neighbors", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
   testRunner.Given("I have a cell with x = 1 and y = 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
   testRunner.Given("I have a different cell with x = 0 and y = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
   testRunner.When("I check if the cells are neighbors", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
   testRunner.Then("The two cells are neighbor cells", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cells that are next to each other are neighbors")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NeighborRules")]
        public virtual void CellsThatAreNextToEachOtherAreNeighbors()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cells that are next to each other are neighbors", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
   testRunner.Given("I have a cell with x = 1 and y = 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
   testRunner.Given("I have a different cell with x = 0 and y = 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
   testRunner.When("I check if the cells are neighbors", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
   testRunner.Then("The two cells are neighbor cells", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cells that are not next to each other are not neighbors")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NeighborRules")]
        public virtual void CellsThatAreNotNextToEachOtherAreNotNeighbors()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cells that are not next to each other are not neighbors", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
   testRunner.Given("I have a cell with x = 0 and y = 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
   testRunner.Given("I have a different cell with x = 2 and y = 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
   testRunner.When("I check if the cells are neighbors", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
   testRunner.Then("The two cells are not neighbor cells", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
