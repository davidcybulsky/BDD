Feature: Logging in 
    As a visitor
    I want to be able to log in
    So that I can purchase tickets and see my tickets
Scenario: Visitor logs in
    Given the visitor is not logged in
    When he enters correct email and address 
    And he gives instruction to login
    Then he will be logged in