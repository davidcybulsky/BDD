Feature: Signing up 
    As a visitor
    I want to be able to sign up
    So that I can purchase tickets and see my tickets
Scenario: Visitor signs up
    Given the visitor has his username, email and password in mind
    When he enters username, syntactically valid email, password and wants to register
    Then the account will be created

