Feature: Returning a ticket
    As a visitor
    I want to be able to return a ticket
    So that I can return in
Scenario: Visitor return a ticket
    Given the visitor is logged
    And he sees his tickets
    When he gives instruction to return some ticket
    Then this ticket will be removed from his account