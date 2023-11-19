Feature: Adding an animal
    As a administrator
    I want to be able to add new animal 
    So that I can keep it
Scenario: Administrator adds an animal
    Given administrator is logged in
    And he sees a list of animals
    When he gives instruction to go to page for adding animal
    And he enters information about that animal
    And he gives instruction to add that animal
    Then the animal will be added to list