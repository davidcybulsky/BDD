Feature: Seeing animals of specific species 
    As a user
    I want to be able to see animals of specific species
    So that I know them
Scenario: User checks animals of specific species
    Given user sees list of species
    When he gives instruction to see animals of specific species
    Then the list of animals of that species will be dislpayed