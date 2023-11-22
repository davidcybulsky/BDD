Feature: Adding an animal
    As a administrator
    I want to be able to add new animal 
    So that I can keep it
Scenario: Administrator adds an animal
    Given administrator is logged in to the system
    And he sees that list of animals
    When he gives instruction to go to page for adding animal
    And he enters information about an animal
    And he gives instruction to add that animal
    Then the animal will be added to list