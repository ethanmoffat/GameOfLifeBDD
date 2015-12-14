Feature: PastGenerationList
   In order to simulate the game of life
   As a game of life enthusiast
   I want to have an easy way to view past generations of the world
   
Background:
   Given The application has started

@FunctionalTest
Scenario: Past generations locked when simulation running
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And I have a world with a live cell at 1, 3 displayed
   When I run the simulation in the ui
   Then the past generation list is disabled

@FunctionalTest
Scenario: Past generations unlocked when simulation paused
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And I have a world with a live cell at 1, 3 displayed
     And the simulation has started
   When I pause the simulation in the ui
   Then the past generation list is enabled

@FunctionalTest
Scenario: Past generations locked when simulation resumed
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And I have a world with a live cell at 1, 3 displayed
     And the simulation has started
     And the simulation has been paused
   When I resume the simulation in the ui
   Then the past generation list is disabled

@FunctionalTest
Scenario: Past generations cleared when simulation reset
   Given I have a world with a live cell at 3, 3 displayed
     And I have a world with a live cell at 3, 4 displayed
   When I run the simulation in the ui
    And I let the simulation run
    And I reset the simulation in the ui
   Then the past generation list has no entries
    And the past generation list is enabled

@FunctionalTest
Scenario: Past generations stored and displayed
   Given I have a world with a live cell at 3, 3 displayed
     And I have a world with a live cell at 3, 4 displayed
   When I run the simulation in the ui
    And I let the simulation run
   Then the past generation list has an entry for generation 0
    And the past generation list has an entry for generation 1

@FunctionalTest
Scenario: Selecting past generation displays in grid
   Given I have a world with a live cell at 6, 6 displayed
     And I have a world with a live cell at 7, 6 displayed
     And I have a world with a live cell at 8, 6 displayed
     And I have a world with a live cell at 6, 7 displayed
     And I have a world with a live cell at 8, 7 displayed
     And I have a world with a live cell at 6, 8 displayed
     And I have a world with a live cell at 7, 8 displayed
     And I have a world with a live cell at 8, 8 displayed
     And the simulation has started
   When I let the simulation run
    And I pause the simulation in the ui
    And I select the past generation list entry for generation 4
   Then the grid matches the selected past generation list entry

@FunctionalTest
Scenario: Grid locked when past generation selected
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And the simulation has started
   When I let the simulation run
    And I select the past generation list entry for generation 0
   Then the world should not be editable

@FunctionalTest
Scenario: Grid unlocked when latest generation selected
   Given I have a world with a live cell at 1, 1 displayed
     And I have a world with a live cell at 1, 2 displayed
     And the simulation has started
   When I let the simulation run
    And I select the past generation list entry for generation 0
    And I select the latest past generation entry
   Then the world should be editable