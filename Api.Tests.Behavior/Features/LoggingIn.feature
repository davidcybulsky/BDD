Feature: Logging in 
    As a visitor
    I want to be able to log in
    So that I can purchase tickets and see my tickets
Scenario: Visitor logs in
    Given the visitor remembers his username and password
    And user exists in the database
    When he enters his username and password and wants to log in
    Then he will be logged in