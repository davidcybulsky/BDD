Feature: Buying a ticket
    As a visitor
    I want to be able to buy a ticket
    So that I can go to safari
Scenario: Visitor buys a ticket
    Given the visitor is logged in
    And he chooses the ticket he wants to buy
    When he gives instruction to buy the ticket
    Then the ticket will be added to his account