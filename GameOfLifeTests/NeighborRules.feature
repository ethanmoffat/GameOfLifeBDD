Feature: NeighborRules
   In order to simulate the game of life
   As a pretty cool guy who doesn't afraid of anything
   I want to know how a neighbor is defined in a World

Scenario: Cells with the same coordinates have an error
   Given I have a cell with x = 1 and y = 1
   Given I have a different cell with x = 1 and y = 1
   When I check if the cells are neighbors
   Then An error indicates the two cells are the same cell

Scenario: Diagonal cells are neighbors
   Given I have a cell with x = 1 and y = 1
   Given I have a different cell with x = 0 and y = 0
   When I check if the cells are neighbors
   Then The two cells are neighbor cells

Scenario: Cells that are next to each other are neighbors
   Given I have a cell with x = 1 and y = 1
   Given I have a different cell with x = 0 and y = 1
   When I check if the cells are neighbors
   Then The two cells are neighbor cells

Scenario: Cells that are not next to each other are not neighbors
   Given I have a cell with x = 0 and y = 0
   Given I have a different cell with x = 2 and y = 2
   When I check if the cells are neighbors
   Then The two cells are not neighbor cells