Feature: WorldGrid
   In order to simulate the game of life
   As a game of life enthusiast
   I want to have an easy way to seed and view the world

Background:
   Given The application has started

@FunctionalTest
Scenario: Add a cell to the world
   Given I have a world with a live cell at 1, 1 displayed
   When I select the cell at 1, 2
   Then the cell should display as "alive"
   
@FunctionalTest
Scenario: Remove a cell from the world
   Given I have a world with a live cell at 1, 1 displayed
   When I select the cell at 1, 1
   Then the cell should display as "dead"
   
@FunctionalTest
Scenario: Grid becomes un-editable when running
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And I have a world with a live cell at 1, 3 displayed
   When I run the simulation in the ui
   Then the world should not be editable
   
@FunctionalTest
Scenario: Grid becomes editable when paused
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And I have a world with a live cell at 1, 3 displayed
     And the simulation has started
   When I pause the simulation in the ui
   Then the world should be editable
   
@FunctionalTest
Scenario: Grid becomes un-editable when resumed
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And I have a world with a live cell at 1, 3 displayed
     And the simulation has started
     And the simulation has been paused
   When I resume the simulation in the ui
   Then the world should not be editable
   
@FunctionalTest
Scenario: Grid becomes editable and cleared when reset
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And I have a world with a live cell at 1, 3 displayed
     And the simulation has started
     And the simulation has been paused
   When I reset the simulation in the ui
   Then the world should be editable
    And the world should be reset
    
@FunctionalTest
Scenario: Grid becomes editable and cleared when all cells die
   Given I have a world with a live cell at 1, 2 displayed
     And I have a world with a live cell at 1, 3 displayed
   When I run the simulation in the ui
    And I let the simulation run
   Then the simulation should stop when there are no live cells
    And the world should be editable
    And the world should be reset