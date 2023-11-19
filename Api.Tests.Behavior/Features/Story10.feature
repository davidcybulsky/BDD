Feature: Updating an animal
    As a administrator
    I want to be able to update existing animal 
    So that I can update it
Scenario: Administrator updates an animal
    Given administrator is logged in
    And he sees a list of animals
    When he gives instruction to go to page for updating animal
    And he enters information about that animal
    And he gives instruction to update that animal
    Then the animal will be updated