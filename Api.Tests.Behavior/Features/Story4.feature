Feature: Seeing the price of a ticket
    As a visitor
    I want to be able to see a price of the ticket I want to buy
    So that I can decide if I want to buy it or not
Scenario: Visitor checks the price of ticket
    Given the visitor is logged in
    When he chooses the enclosure he wants to go in
    And he chooses the day 
    Then the price of this specific ticket will be displayed