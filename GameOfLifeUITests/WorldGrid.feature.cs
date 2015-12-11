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
namespace GameOfLifeUITests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WorldGridFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WorldGrid.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WorldGrid", " In order to simulate the game of life\n As a game of life enthusiast\n I want to h" +
                    "ave an easy way to seed and view the world", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "WorldGrid")))
            {
                GameOfLifeUITests.WorldGridFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
   testRunner.Given("The application has started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add a cell to the world")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorldGrid")]
        public virtual void AddACellToTheWorld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a cell to the world", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 10
   testRunner.Given("I have a world with a live cell at 1, 1 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
   testRunner.When("I select the cell at 1, 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
   testRunner.Then("the cell should display as \"alive\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Remove a cell from the world")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorldGrid")]
        public virtual void RemoveACellFromTheWorld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove a cell from the world", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 15
   testRunner.Given("I have a world with a live cell at 1, 1 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
   testRunner.When("I select the cell at 1, 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
   testRunner.Then("the cell should display as \"dead\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Grid becomes un-editable when running")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorldGrid")]
        public virtual void GridBecomesUn_EditableWhenRunning()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Grid becomes un-editable when running", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 20
   testRunner.Given("I have a world with a live cell at 1, 1 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
     testRunner.And("I have a world with a live cell at 1, 2 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
     testRunner.And("I have a world with a live cell at 1, 3 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
   testRunner.When("I run the simulation in the ui", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
   testRunner.Then("the world should not be editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Grid becomes editable when paused")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorldGrid")]
        public virtual void GridBecomesEditableWhenPaused()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Grid becomes editable when paused", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 27
   testRunner.Given("I have a world with a live cell at 1, 1 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
     testRunner.And("I have a world with a live cell at 1, 2 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
     testRunner.And("I have a world with a live cell at 1, 3 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
     testRunner.And("the simulation has started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
   testRunner.When("I pause the simulation in the ui", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
   testRunner.Then("the world should be editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Grid becomes un-editable when resumed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorldGrid")]
        public virtual void GridBecomesUn_EditableWhenResumed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Grid becomes un-editable when resumed", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 35
   testRunner.Given("I have a world with a live cell at 1, 1 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
     testRunner.And("I have a world with a live cell at 1, 2 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
     testRunner.And("I have a world with a live cell at 1, 3 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
     testRunner.And("the simulation has started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
     testRunner.And("the simulation has been paused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
   testRunner.When("I resume the simulation in the ui", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
   testRunner.Then("the world should not be editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Grid becomes editable and cleared when reset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorldGrid")]
        public virtual void GridBecomesEditableAndClearedWhenReset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Grid becomes editable and cleared when reset", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 44
   testRunner.Given("I have a world with a live cell at 1, 1 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
     testRunner.And("I have a world with a live cell at 1, 2 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
     testRunner.And("I have a world with a live cell at 1, 3 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
     testRunner.And("the simulation has started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
     testRunner.And("the simulation has been paused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
   testRunner.When("I reset the simulation in the ui", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
   testRunner.Then("the world should be editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
    testRunner.And("the world should be reset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Grid becomes editable and cleared when all cells die")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorldGrid")]
        public virtual void GridBecomesEditableAndClearedWhenAllCellsDie()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Grid becomes editable and cleared when all cells die", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 54
   testRunner.Given("I have a world with a live cell at 1, 2 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
     testRunner.And("I have a world with a live cell at 1, 3 displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
   testRunner.When("I run the simulation in the ui", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
    testRunner.And("I let the simulation run", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
   testRunner.Then("the simulation should stop when there are no live cells", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
    testRunner.And("the world should be editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
    testRunner.And("the world should be reset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion