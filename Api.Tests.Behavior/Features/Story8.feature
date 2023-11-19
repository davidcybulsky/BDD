Feature: Seeing specific animal
    As a user
    I want to be able to see info about specific animal
    So that I know something about it
Scenario: User checks specific animal
    Given user sees list of animals
    When he gives instruction to see details of specific animal
    Then the information about that animal will be displayed