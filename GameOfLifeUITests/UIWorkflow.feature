Feature: UIWorkflow
   In order to simulate the Game of Life
   As a science enthusiast who enjoys silly games
   I want to be able to easily see the Game of Life world as a simulation runs

# "The background is run before each of your scenarios but after any of your Before Hooks."
# See https://github.com/cucumber/cucumber/wiki/Background
Background: 
   Given I have started the application

Scenario: Seed a world with live cells
   Given The simulation is not running
   When I add a seed cell to the world
   Then The cell is reflected in the display of the world

Scenario: Run the simulation
   Given The simulation is not running
   And I have a world that is seeded with at least one live cell
   When I run the game of life simulation
   Then The simulation enters the running state

Scenario: Pause the simulation
   Given The simulation is running
   When I pause the simulation
   Then The simulation enters the paused state

Scenario: Resume the simulation
   Given The simulation is paused
   When I resume the simulation
   Then The simulation enters the running state

Scenario: Reset the simulation
   Given The simulation is paused
   When I reset the world
   Then The simulation enters the initial state
      And The world is set to the initial state

Scenario: View previous generations
   Given The simulation is paused
   When I select a previous world generation
   Then The previous generation is displayed

Scenario: Simulation stops when all cells are dead
   Given The simulation is running
   When The current generation has no live cells
      And The previous generation has at least one live cell
   Then The simulation enters the initial state
      And The world is set to the initial state