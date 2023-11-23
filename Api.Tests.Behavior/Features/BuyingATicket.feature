Feature: Buying a ticket
    As a visitor
    I want to be able to buy a ticket
    So that I can go to safari
Scenario: Visitor buys a ticket
    Given visitor is logged in
    And there are available tickets
    When he chooses the ticket he wants to buy
    And chooses the date
    And he gives instruction to buy the ticket
    Then the ticket will be added to his account