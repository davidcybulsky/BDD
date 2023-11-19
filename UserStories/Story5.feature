Feature: Buying a ticket
    As a visitor
    I want to be able to buy a ticket
    So that I can go to safari
Scenario: Visitor buys a ticket
    Given the visitor is logged in
    And he chose the enclosure he wants to go in
    And he chose the day 
    When he gives instruction to buy the ticket
    Then the ticket will be added to his account