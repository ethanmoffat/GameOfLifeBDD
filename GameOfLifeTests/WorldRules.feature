Feature: WorldRules
   In order to simulate a world of cells in Conway's Game of Life
   As a scientist
   I want to know the rules of the world

#Background example: Statement executed for each scenario defined below
#Background:
#   Given a world with a live cell

Scenario: Live cells die due to underpopulation
   Given a world with a live cell
   And the cell has less than 2 live neighbors
   When I get the next generation of the world
   Then the cell should be dead

Scenario: Live cells with 2 neighbors live on to next generation
   Given a world with a live cell
   And the cell has 2 live neighbors
   When I get the next generation of the world
   Then the cell should be alive

Scenario: Live cells with 3 neighbors live on to next generation
   Given a world with a live cell
   And the cell has 3 live neighbors
   When I get the next generation of the world
   Then the cell should be alive

Scenario: Live cells die due to overpopulation
   Given a world with a live cell
   And the cell has greater than 3 live neighbors
   When I get the next generation of the world
   Then the cell should be dead

Scenario: Dead cells come back to life
   Given a world with a dead cell
   And the cell has 3 live neighbors
   When I get the next generation of the world
   Then the cell should be alive

Scenario: Dead cells stay dead
   Given a world with a dead cell
   And the dead cell does not have exactly 3 live neighbors
   When I get the next generation of the world
   Then the cell should be dead

#Scenario Outline example for "Live cells die due to overpopulation"
Scenario Outline: Too Many Neighbors Dies
   Given a world with a live cell
   And the cell has <numberOfLiveNeighbors> live neighbors
   When I get the next generation of the world
   Then the cell should be dead

   Examples: 
   | numberOfLiveNeighbors |
   | 4                     |
   | 5                     |
   | 8                     |
