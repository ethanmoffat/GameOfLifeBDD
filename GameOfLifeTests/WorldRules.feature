Feature: WorldRules
   In order to simulate a world of cells in Conway's Game of Life
   As a scientist
   I want to know the rules of the world

#Background example: Statement executed for each scenario defined below
Background:
   Given a world with a live cell

Scenario: Live cells die due to underpopulation
   Given the cell has less than 2 live neighbors
   When I get the next generation of the world
   Then the cell should be dead

Scenario Outline: Live cells die due to underpopulation (outline)
   Given the cell has <numberOfLiveNeighbors> live neighbors
   When I get the next generation of the world
   Then the cell should be dead

   Examples:
   | numberOfLiveNeighbors |
   | 0                     |
   | 1                     |

Scenario Outline: Live cells with 2 or 3 neighbors live on to next generation
   Given the cell has <numberOfLiveNeighbors> live neighbors
   When I get the next generation of the world
   Then the cell should be alive

   Examples:
   | numberOfLiveNeighbors |
   | 2                     |
   | 3                     |

Scenario Outline: Live cells die due to overpopulation
   Given the cell has <numberOfLiveNeighbors> live neighbors
   When I get the next generation of the world
   Then the cell should be dead

   Examples: 
   | numberOfLiveNeighbors |
   | 4                     |
   | 5                     |
   | 6                     |
   | 7                     |
   | 8                     |

Scenario: Dead cells come back to life
   Given a world with a dead cell
   And the cell has 3 live neighbors
   When I get the next generation of the world
   Then the cell should be alive

Scenario Outline: Dead cells stay dead
   Given a world with a dead cell
   And the cell has <numberOfLiveNeighbors> live neighbors
   When I get the next generation of the world
   Then the cell should be dead

   Examples: 
   | numberOfLiveNeighbors |
   | 0                     |
   | 1                     |
   | 2                     |
   | 4                     |
   | 5                     |
   | 6                     |
   | 7                     |
   | 8                     |