﻿Feature: WorldRules
   In order to simulate a world of cells
   As a scientist interested in silly games
   I want to know the discrete rules of the world

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

Scenario: Duplicate cells are not allowed
   Given a world with a cell at 4, 5
   When I seed the world with an additional cell at 4, 5
   Then there should be an error indicating duplicate cells