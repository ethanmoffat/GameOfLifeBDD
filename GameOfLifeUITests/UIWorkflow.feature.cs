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
    public partial class UIWorkflowFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UIWorkflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UIWorkflow", " In order to simulate the Game of Life\n As a science enthusiast who enjoys silly " +
                    "games\n I want to be able to easily see the Game of Life world as a simulation ru" +
                    "ns", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "UIWorkflow")))
            {
                GameOfLifeUITests.UIWorkflowFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Seed a world with live cells")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UIWorkflow")]
        public virtual void SeedAWorldWithLiveCells()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Seed a world with live cells", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
   testRunner.Given("The simulation is not running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
   testRunner.When("I add a seed cell to the world", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
   testRunner.Then("The world is seeded with the cell", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Run the simulation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UIWorkflow")]
        public virtual void RunTheSimulation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run the simulation", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
   testRunner.Given("The simulation is not running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
   testRunner.And("I have a world that is seeded with at least one live cell", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
   testRunner.When("I run the game of life simulation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
   testRunner.Then("The simulation enters the running state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Pause the simulation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UIWorkflow")]
        public virtual void PauseTheSimulation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pause the simulation", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
   testRunner.Given("The simulation is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
   testRunner.When("I pause the simulation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
   testRunner.Then("The simulation enters the paused state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Resume the simulation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UIWorkflow")]
        public virtual void ResumeTheSimulation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resume the simulation", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
   testRunner.Given("The simulation is paused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
   testRunner.When("I resume the simulation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
   testRunner.Then("The simulation enters the running state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reset the simulation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UIWorkflow")]
        public virtual void ResetTheSimulation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reset the simulation", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
   testRunner.Given("The simulation is paused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
   testRunner.When("I reset the simulation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
   testRunner.Then("The simulation enters the initial state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
      testRunner.And("The world is set to the initial state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Simulation stops when all cells are dead")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UIWorkflow")]
        public virtual void SimulationStopsWhenAllCellsAreDead()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Simulation stops when all cells are dead", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
   testRunner.Given("The simulation is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
   testRunner.When("The current generation has no live cells", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
      testRunner.And("The previous generation has at least one live cell", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
   testRunner.Then("The simulation enters the initial state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
      testRunner.And("The world is set to the initial state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
