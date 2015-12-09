Feature: NeighborRules
   In order to simulate the game of life
   As a pretty cool guy who doesn't afraid of anything
   I want to know how a neighbor is defined in a World

Scenario: Cells with the same coordinates have an error
   Given I have a cell
      And The cell has an x coordinate of 1
      And The cell has a y coordinate of 1
   Given I have a cell
      And The cell has an x coordinate of 1
      And The cell has a y coordinate of 1
   When I check if the cells are neighbors
   Then An error indicates the two cells are the same cell

Scenario: Diagonal cells are neighbors
   Given I have a cell
      And The cell has an x coordinate of 1
      And The cell has a y coordinate of 1
   Given I have a cell
      And The cell has an x coordinate of 0
      And The cell has a y coordinate of 0
   When I check if the cells are neighbors
   Then The two cells are neighbor cells

Scenario: Cells that are next to each other are neighbors
   Given I have a cell
      And The cell has an x coordinate of 1
      And The cell has a y coordinate of 1
   Given I have a cell
      And The cell has an x coordinate of 0
      And The cell has a y coordinate of 1
   When I check if the cells are neighbors
   Then The two cells are neighbor cells

Scenario: Cells that are not next to each other are not neighbors
   Given I have a cell
      And The cell has an x coordinate of 0
      And The cell has a y coordinate of 0
   Given I have a cell
      And The cell has an x coordinate of 2
      And The cell has a y coordinate of 2
   When I check if the cells are neighbors
   Then The two cells are not neighbor cells