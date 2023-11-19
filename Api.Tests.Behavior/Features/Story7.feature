Feature: Seeing animals
    As a user
    I want to be able to see animals that are currently in safari
    So that I know what animals are there
Scenario: User checks animals
    Given user is on site
    When he gives instruction to see animals
    Then animals will be displayed