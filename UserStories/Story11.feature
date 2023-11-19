Feature: Removing an animal
    As a administrator
    I want to be able to remove animal 
    So that I can remove it
Scenario: Administrator removes an animal
    Given administrator is logged in
    And he sees a list of animals
    When he gives instruction to remove specific animal
    And he agrees that he is sure he wants to do it
    Then the animal will be removed from the list
